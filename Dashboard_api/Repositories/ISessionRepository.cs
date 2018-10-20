/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** ISessionRepository
*/

using System.Collections.Generic;

namespace Dashboard.Models
{
    public interface ISessionRepository
    {
        IEnumerable<Session> GetAll();
        long CountAll();
        Session Get(string id);
        Session GetByUserId(string userId);
        Session Add(Session item);
        bool Remove(string id);
        Session Update(string id, Session item);
    }
}
