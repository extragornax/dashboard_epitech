/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** IUserRepository
*/

using System.Collections.Generic;

namespace Dashboard.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        long CountAll();
        User Get(string id);
        User GetByName(string name);
        User Add(User item);
        bool Remove(string id);
        User Update(string id, User item);
    }
}
