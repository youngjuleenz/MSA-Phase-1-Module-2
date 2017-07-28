using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Tabs.Model;
using Xamarin.Forms;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace Tabs
{
    public partial class CustomVision : ContentPage
    {
        const string APIKEY = "375b1d9f138743ee92530b994c47592f";
        EmotionServiceClient emotionServiceClient = new EmotionServiceClient(APIKEY);
        Emotion[] emotionAnalysis;
        MediaFile file;

        public CustomVision()
        {
            InitializeComponent();
        }

        private async void loadCamera(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                Directory = "Sample",
                Name = $"{DateTime.UtcNow}.jpg"
            });

            if (file == null)
            {
                return;
            }

            image.Source = ImageSource.FromStream(() =>
            {
                return file.GetStream();
            });

            analyseEmotion(file);
        }

        private async void analyseEmotion(MediaFile file)
        {
            emotionAnalysis = await emotionServiceClient.RecognizeAsync(file.GetStream());
            if (emotionAnalysis != null)
            {
                AnalysisResult.Text = "You are feeling... " + emotionAnalysis.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key + " !";
                //"Your emotions are: \n" +
                //"Neutral: " + emotionAnalysis[0].Scores.Neutral +
                //"\t \t Surprise: " + emotionAnalysis[0].Scores.Surprise + "\n" +
                //"Fear: " + emotionAnalysis[0].Scores.Fear + "\n" +
                //"Anger: " + emotionAnalysis[0].Scores.Anger + "\n" +
                //"Disgust: " + emotionAnalysis[0].Scores.Disgust + "\n" +
                //"Happiness: " + emotionAnalysis[0].Scores.Disgust + "\n" +
                //"Sadness: " + emotionAnalysis[0].Scores.Sadness + "\n" +
                //"Contempt: " + emotionAnalysis[0].Scores.Contempt + "\n";
                
            }
            else
            {
                return;
            }

        }
                
    }
}