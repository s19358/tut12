using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut12.DTOs;
using tut12.Models;

namespace tut12.Services
{
    public class SqlServerOrderDbService : IOrderDbService
    {

        private readonly DBContext _dbcontext;
        public SqlServerOrderDbService(DBContext context)
        {
            _dbcontext = context;
        }
        public IEnumerable getOrders(string name)
        {
              if (name != null) {
            
                  var res = _dbcontext.Customer.Any(e => e.Name == name);

                  if (res == true)
                  {

                      var id = _dbcontext.Customer.Where(e => e.Name == name).Select(e=>e.IdClient).FirstOrDefault();

                    
                    var res2 = _dbcontext.Order.Where(e => e.IdClient == id).Join(_dbcontext.Confectionery_Order, e => e.IdOrder, d => d.IdOrder,
                        (e, d) => new
                        {
                            Order = e,
                            Confectionery_Order1 = d
                        }).Join(_dbcontext.Confectionery, e => e.Confectionery_Order1.IdConfectionery, d => d.IdConfectionery,
                        (e, d) => new
                        {
                            Confectionery = d,
                            Confectionery_Order2 = e
                        }).Select(e => new {
                            e.Confectionery_Order2.Order.IdOrder,
                            e.Confectionery_Order2.Order.DateAccepted,
                            e.Confectionery_Order2.Order.DateFinished,
                            e.Confectionery_Order2.Order.Notes,
                           //Confectionery= e.Confectionery,
                            
                            Confectionery = new
                            {
                                e.Confectionery.IdConfectionery,
                                e.Confectionery.Name,
                               e.Confectionery.PricePerItem,
                                e.Confectionery_Order2.Confectionery_Order1.Quantity


                            }
                            

                        }).ToList();

                   return res2;
     
                  }
                  else
                  {
                    //return NotFound("There is no customer with name " + name);
                    throw new Exception("There is no customer with name " + name);
                  }
                 
              } else
              {
                // var list = _dbcontext.Order.Select(e => new { e.IdOrder, e.DateAccepted, e.DateFinished, e.Notes }).ToList();

               

                var list = _dbcontext.Order.Join(_dbcontext.Confectionery_Order, e => e.IdOrder, d => d.IdOrder,
                          (e, d) => new
                          {
                              Order = e,
                              Confectionery_Order1 = d
                          }).Join(_dbcontext.Confectionery, e => e.Confectionery_Order1.IdConfectionery, d => d.IdConfectionery,
                          (e, d) => new
                          {
                              Confectionery = d,
                              Confectionery_Order2 = e
                          }).Select(e => new {
                              e.Confectionery_Order2.Order.IdOrder,
                              e.Confectionery_Order2.Order.DateAccepted,
                              e.Confectionery_Order2.Order.DateFinished,
                              e.Confectionery_Order2.Order.Notes,
                              Confectionery= new
                              {
                                  e.Confectionery.IdConfectionery,
                                  e.Confectionery.Name,
                                  e.Confectionery.PricePerItem,
                                  e.Confectionery_Order2.Confectionery_Order1.Quantity
                              }
                              
                          }).ToList();
                //return Ok(list);'


                return list;
               }
        }

        public string newOrder(int id, NewOrderRequest req)
        {
            var res = _dbcontext.Customer.Any(e => e.IdClient == id);

            if (res == true)
            {
                var result = _dbcontext.Confectionery.Where(x => req.Confectionery.Select(e => e.Name).Contains(x.Name)).Any();
                _dbcontext.Database.BeginTransaction();

                if (result == true)
                {
                    try
                    {

                        var newOrd = new Order
                        {
                            DateAccepted = req.DateAccepted,
                            DateFinished = req.DateAccepted.AddDays(7),
                            Notes = req.Notes,
                            IdClient = id,
                            IdEmployee = 1
                          
                          
                        };
                        
                        _dbcontext.Order.Add(newOrd);
                        _dbcontext.SaveChanges();

                        for (int i = 0; i < req.Confectionery.Count(); i++)
                        {
                            var add = new Confectionery_Order
                            {
                                IdConfectionery = _dbcontext.Confectionery.Where(e => e.Name == req.Confectionery.ElementAt(i).Name)
                                                            .Select(e => e.IdConfectionery).FirstOrDefault(),
                                IdOrder = _dbcontext.Order.Max(e => e.IdOrder),
                                Quantity = Int32.Parse(req.Confectionery.ElementAt(i).Quantity),
                                Notes = req.Confectionery.ElementAt(i).Notes

                            };
                            _dbcontext.Confectionery_Order.Add(add);
                            _dbcontext.SaveChanges();
                        }
                       
                        _dbcontext.Database.CommitTransaction();
                        //return Ok("Added succesfully!");
                        return "Added succesfully";
                    }
                    catch (Exception e)
                    {
                        _dbcontext.Database.RollbackTransaction();
                        //return BadRequest("there is a problem");

                        throw new Exception("there is a problem!");
                    }
                }
                else
                {
                    //return BadRequest("dont have this product");
                    throw new Exception("There is no such a product");
                }

            }
            else
            {

                //return NotFound("There is no client with id " + id);
                throw new Exception("There is no client with id " + id);
            }
        }
    }
}
