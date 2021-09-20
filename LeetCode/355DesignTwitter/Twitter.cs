using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._355DesignTwitter
{
    public class Twitter
    {
        private Dictionary<int, Data> _dictionary;
        private int couter;

        /** Initialize your data structure here. */
        public Twitter()
        {
            _dictionary = new Dictionary<int, Data>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (!_dictionary.ContainsKey(userId))
            {
                _dictionary.Add(userId, new Data());
            }

            _dictionary[userId].TweetList.Add(new TweetItem {Id = tweetId, SerialId = couter++});
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed.
         * Each item in the news feed must be posted by users who the user followed or by the user herself.
         * Tweets must be ordered from most recent to least recent.
         */
        public IList<int> GetNewsFeed(int userId)
        {
            if (!_dictionary.ContainsKey(userId))
            {
                return new List<int>();
            }
            else
            {
                var data = _dictionary[userId];
                List<TweetItem> allTweets = data.TweetList.ToList();
                data.FollowList.ForEach(i => { allTweets.AddRange(_dictionary[i].TweetList); });
                allTweets.Sort((i, i1) => (int) ((i1.SerialId - i.SerialId)));
                return allTweets.Take(10).Select(item => item.Id).ToList();
            }
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (!_dictionary.ContainsKey(followerId))
            {
                _dictionary.Add(followerId, new Data());
            }

            if (!_dictionary.ContainsKey(followeeId))
            {
                _dictionary.Add(followeeId, new Data());
            }

            if (!_dictionary[followerId].FollowList.Contains(followeeId))
            {
                _dictionary[followerId].FollowList.Add(followeeId);
            }
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (!_dictionary.ContainsKey(followerId))
            {
                return;
            }

            if (_dictionary[followerId].FollowList.Contains(followeeId))
            {
                _dictionary[followerId].FollowList.Remove(followeeId);
            }
        }

        private class Data
        {
            public List<TweetItem> TweetList { get; set; }
            public List<int> FollowList { get; set; }

            public Data()
            {
                TweetList = new List<TweetItem>();
                FollowList = new List<int>();
            }
        }

        private class TweetItem
        {
            public int Id { get; set; }
            public int SerialId { get; set; }
        }
    }

    /**
     * Your Twitter object will be instantiated and called as such:
     * Twitter obj = new Twitter();
     * obj.PostTweet(userId,tweetId);
     * IList<int> param_2 = obj.GetNewsFeed(userId);
     * obj.Follow(followerId,followeeId);
     * obj.Unfollow(followerId,followeeId);
     */
}