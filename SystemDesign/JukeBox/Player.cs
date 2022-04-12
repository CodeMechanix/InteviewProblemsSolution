using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.JukeBox
{
    public class Player
    {
        private CancellationTokenSource token;
        public Task PlayTask { get; private set; }

        public async Task Play(Song song)
        {
            token = new CancellationTokenSource();

            for (int i = 0; i < song.Duration; i++)
            {
                PlayTask = Task.Delay(1000, token.Token);
                await PlayTask;
                Debug.WriteLine($"Playing song: {song.Name} - {i}sec");
            }
        }

        public void Stop()
        {
            Debug.WriteLine($"Stop");
            token.Cancel(true);
        }

     
    }
}