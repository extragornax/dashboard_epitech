/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** User
*/

using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dashboard.Models
{

    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId SessionId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
