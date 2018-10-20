/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** Session
*/

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dashboard.Models
{
    public class Session
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
    }
}
