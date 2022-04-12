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
        private Task playTask;

        public async Task Play(string songName = "Track1")
        {
            token = new CancellationTokenSource();

            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(1000, token.Token);
                Debug.WriteLine($"Playing song: {songName} - {i}");
            }
        }

        public void Stop()
        {
            Debug.WriteLine($"Stop");
            token.Cancel(true);
        }

     
    }
}