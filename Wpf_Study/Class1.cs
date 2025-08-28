using System;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;   // Orientation
using System.Windows.Media.Animation;
using System.IO;                 // Stream
using System.Windows.Input;
using System.Windows.Media;
namespace Shake
{

    public static class WindowHelper
    {
        /// <summary>
        /// 窗口抖动动画
        /// </summary>
        public static void WindowShake(
            Window window = null,
            Orientation orientation = Orientation.Horizontal,
            double shakeRange = 15,
            double duration = 50,
            double repeatCount = 3,
            Uri wavUri = null)
        {
            if (window == null)
            {
                if (Application.Current.Windows.Count > 0)
                {
                    window = Application.Current.Windows
                        .OfType<Window>()
                        .FirstOrDefault(w => w.IsActive);
                }
            }

            // 使用旧写法替换 is not null
            if (window != null)
            {
                double baseValue;

                if (orientation == Orientation.Horizontal)
                {
                    window.BeginAnimation(Window.LeftProperty, null);
                    baseValue = window.Left;
                }
                else
                {
                    window.BeginAnimation(Window.TopProperty, null);
                    baseValue = window.Top;
                }

                var doubleAnimation = new DoubleAnimation
                {
                    From = baseValue,
                    To = baseValue + shakeRange,
                    Duration = TimeSpan.FromMilliseconds(duration),
                    AutoReverse = true,
                    RepeatBehavior = new RepeatBehavior(repeatCount),
                    FillBehavior = FillBehavior.Stop
                };

                doubleAnimation.Completed += (s, e) =>
                {
                    if (orientation == Orientation.Horizontal)
                    {
                        window.BeginAnimation(Window.LeftProperty, null);
                        window.Left = baseValue;
                    }
                    else
                    {
                        window.BeginAnimation(Window.TopProperty, null);
                        window.Top = baseValue;
                    }
                };

                if (orientation == Orientation.Horizontal)
                    window.BeginAnimation(Window.LeftProperty, doubleAnimation);
                else
                    window.BeginAnimation(Window.TopProperty, doubleAnimation);
                //点击抖动时候的声音


                /* 播放本地 MP3 —— 用 MediaPlayer 代替 SoundPlayer */
                if (wavUri == null)
                    wavUri = new Uri(@"F:\All--Code\C_Sharp\wPF_study\Wpf_Study_solution\eshake.mp3");

                var media = new System.Windows.Media.MediaPlayer();
                media.Open(wavUri);
                media.Play();
                // 使用旧写法替换 ??=
                /*if (wavUri == null)
                    wavUri = new Uri("pack://application:,,,/CustomControlSamples;component/Asset/audio/eshake.wav");

                var streamResource = Application.GetResourceStream(wavUri);
                if (streamResource != null)
                {
                    using (var soundPlayer = new SoundPlayer(streamResource.Stream))
                    {
                        soundPlayer.Play();
                    }
                }*/
            }
        }
    }
}