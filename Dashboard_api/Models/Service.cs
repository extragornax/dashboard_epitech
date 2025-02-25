/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** Service
*/

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dashboard.Models
{

    public class Service
    {

        public Service()
        {
            Name = "";
            Widgets = new List<Widgets.IWidget>();
        }
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<Widgets.IWidget> Widgets { get; set; }
    }
}
