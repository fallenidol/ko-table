﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Newtonsoft.Json;

public class PersonRepository : IRepository<Person>
{
    private List<Person> _allPeople = new List<Person>();

    public PersonRepository()
    {
        var jsonFile = HttpContext.Current.Server.MapPath("~/_dataSource.json");
        var jsonText = File.ReadAllText(jsonFile);

        var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(jsonText).OrderBy(p => p.id);

        _allPeople.AddRange(people);
    }

    public IEnumerable<Person> Get()
    {
        return _allPeople.AsEnumerable();
    }

    public IEnumerable<Person> Get(Expression<Func<Person, bool>> predicate)
    {
        return _allPeople.Where(predicate.Compile()).AsEnumerable();
    }

    public Person Get(int id)
    {
        return _allPeople.FirstOrDefault(p => p.id == id);
    }

    public int InsertOrUpdate(Person entry)
    {
        if (!entry.id.HasValue)
        {
            entry.id = _allPeople.Max(p => p.id) + 1;
        }
        var match = _allPeople.FirstOrDefault(p => p.id == entry.id);

        if (_allPeople.Contains(match))
        {
            _allPeople.Remove(match);
        }

        _allPeople.Add(entry);

        return entry.id.Value;
    }

    public void Delete(int id)
    {
        var match = _allPeople.FirstOrDefault(p => p.id == id);

        if (_allPeople.Contains(match))
        {
            _allPeople.Remove(match);
        }
    }

    public void Dispose()
    {
        _allPeople = null;
    }
}