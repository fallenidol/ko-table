﻿using System.Collections.Generic;
using System.Web.Http;

public class PersonController : ApiController
{
    private static readonly PersonRepository Repository = new PersonRepository();

    // GET api/<controller>
    public IEnumerable<Person> Get()
    {
        //System.Threading.Thread.Sleep(2000);
        return Repository.Get();
    }

    // GET api/<controller>/5
    public Person Get(int id)
    {
        //System.Threading.Thread.Sleep(2000);
        return Repository.Get(id);
    }

    // POST api/<controller>
    public int Post([FromBody] Person value)
    {
        //System.Threading.Thread.Sleep(2000);
        return Repository.InsertOrUpdate(value);
    }
    
    // DELETE api/<controller>/5
    public void Delete(int id)
    {
        //System.Threading.Thread.Sleep(2000);
        Repository.Delete(id);
    }
}