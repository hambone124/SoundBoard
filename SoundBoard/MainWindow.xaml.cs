﻿using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace SoundBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private Uri[] fileLocations = new Uri[8];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                string newButtonName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                var buttonNumberDialog = new ButtonLoad();
                if (buttonNumberDialog.ShowDialog() == true)
                {
                    int buttonNumber = buttonNumberDialog.ResponseText;
                    if (buttonNumber > 0 && buttonNumber < 9)
                    {
                        fileLocations[buttonNumber - 1] = fileUri;
                        Console.WriteLine("URI: " + fileLocations[buttonNumber - 1]);
                        SetButtonText(buttonNumber, newButtonName);
                    } else
                    {
                        MessageBox.Show("Must be a number from 1 to 8.");
                    }
                }
            }                
        }

        private void SetButtonText(int buttonNumber, string fileName)
        {
            switch (buttonNumber)
            {
                case 1:
                    Button1.Content = fileName;
                    break;
                case 2:
                    Button2.Content = fileName;
                    break;
                case 3:
                    Button3.Content = fileName;
                    break;
                case 4:
                    Button4.Content = fileName;
                    break;
                case 5:
                    Button5.Content = fileName;
                    break;
                case 6:
                    Button6.Content = fileName;
                    break;
                case 7:
                    Button7.Content = fileName;
                    break;
                case 8:
                    Button8.Content = fileName;
                    break;
            }
        }

        private void PlaySoundFile(int buttonNumber)
        {
            Console.WriteLine("Playing " + fileLocations[buttonNumber - 1]);
            mediaPlayer.Open(fileLocations[buttonNumber - 1]);
            mediaPlayer.Play();
        }

        private void PlayButton1_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(1);
        }

        private void PlayButton2_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(2);
        }

        private void PlayButton3_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(3);
        }

        private void PlayButton4_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(4);
        }

        private void PlayButton5_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(5);
        }

        private void PlayButton6_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(6);
        }

        private void PlayButton7_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(7);
        }

        private void PlayButton8_Click(object sender, RoutedEventArgs e)
        {
            PlaySoundFile(8);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            LayoutManager.SaveLayoutToFile(fileLocations);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LayoutManager.LoadLayoutFromFile(ref fileLocations);
            for (int i = 0; i < fileLocations.Length; i++)
            {
                int buttonNumber = i + 1;
                if (fileLocations[i] != null)
                {
                    string buttonName = System.IO.Path.GetFileNameWithoutExtension(fileLocations[i].LocalPath);
                    SetButtonText(buttonNumber, buttonName);
                } else
                {
                    SetButtonText(buttonNumber, "Unused");
                }
            }
        }
    }
}
