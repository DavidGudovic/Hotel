using System.Collections.Concurrent;

namespace Hotel.Middleware
{
    // A list of deleted users, disctionary used since ConccurentBag has no normal .TryRemove function for some reason
    public static class InvalidatedUsersList
    {
        private static ConcurrentDictionary<string, bool> _invalidatedUsers = new ConcurrentDictionary<string, bool>();

        public static void AddInvalidatedUser(string userId)
        {
            _invalidatedUsers.TryAdd(userId, true);
        }

        public static void RemoveInvalidatedUser(string userID)
        {
            _invalidatedUsers.TryRemove(userID, out _);
        }

        public static bool IsUserInvalidated(string username)
        {
            if(_invalidatedUsers.TryGetValue(username, out _))
            {
                RemoveInvalidatedUser(username);
                return true;
            }
            return false;
        }
    }

}
