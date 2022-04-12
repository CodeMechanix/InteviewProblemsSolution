using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.JukeBox
{
    public class JukeBoxScheduler
    {
        private ConcurrentBag<Song> _songs;
        private Player _player;
        private Song currentSong;

        public JukeBoxScheduler(ConcurrentBag<Song> songs, Player player, Song currentSong)
        {
            _songs = songs;
            _player = player;
            this.currentSong = currentSong;
        }

        public void Run()
        {
            Task.Run(Action);
        }

        private void Action()
        {
            while (true)
            {
                if (_songs.Count > 0)
                {
                    Song result;
                    _songs.TryTake(out result);
                    currentSong.Name = result.Name;
                    currentSong.Duration = result.Duration;
                    Debug.WriteLine($"Schedule next song to player: {currentSong}");
                    _player.Play(currentSong).Wait();
                }
                else
                {
                    Debug.WriteLine("Waiting for player");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}