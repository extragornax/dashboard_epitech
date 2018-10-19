using System.Collections.Generic;

namespace dashboard_api.Models {
    public interface ISessionRepository {
        IEnumerable<Session> GetAll();
        long CountAll();
        Session Get(string id);
        Session GetByUserId(string userId);
        Session Add(Session item);
        bool Remove(string id);
        Session Update(string id, Session item);
    }
}
