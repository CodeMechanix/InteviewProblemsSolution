using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.JukeBox
{
    public class JukeBox
    {
        private Player _player;
        private ConcurrentBag<Song> _songs;
        private Song _currentSong;
        private JukeBoxScheduler _scheduler;
        private JukeBoxUI _ui;

        public JukeBox()
        {
            _player = new Player();
            _songs = new ConcurrentBag<Song>();
            _currentSong = new Song();

            _ui = new JukeBoxUI(_songs, _currentSong);
            _scheduler = new JukeBoxScheduler(_songs, _player, _currentSong);

            _scheduler.Run();
            _ui.Run();
        }

        public void AddSong(Song song)
        {
            Debug.WriteLine($"Add new song: {song}");
            _songs.Add(song);
        }
    }

    public class JukeBoxUI
    {
        private ConcurrentBag<Song> _songs;
        private readonly Song currentSong;

        private StringBuilder stringBuilder;

        public JukeBoxUI(ConcurrentBag<Song> songs, Song currentSong)
        {
            this._songs = songs;
            this.currentSong = currentSong;
            this.stringBuilder = new StringBuilder();
        }

        public void Run()
        {
            Task.Run(Action);
        }

        private void Action()
        {
            while (true)
            {
                Thread.Sleep(500);
                Debug.WriteLine(ToString());
            }
        }

        public override string ToString()
        {
            stringBuilder.Clear();
            stringBuilder.Append(string.Join(Environment.NewLine, Enumerable.Repeat(string.Empty, 100)));
            stringBuilder.Append($"========================================\n");
            stringBuilder.Append($"Playing: {currentSong}\n");
            stringBuilder.Append($"========================================\n");
            stringBuilder.Append($"Play List: {string.Join(Environment.NewLine, _songs)}\n");
            stringBuilder.Append($"========================================\n");
            return stringBuilder.ToString();
        }
    }
}
