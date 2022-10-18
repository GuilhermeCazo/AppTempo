using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppTempo.Model;
using AppTempo.Services;

namespace AppTempo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Previsao Tempo";

            this.BindingContext = new Tempo();
        }

        private async void btnPrevisao_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cidadeEntry.Text))
                {
                    Console.WriteLine("____________________________");

                    Tempo previsaoDoTempo = await DataService.GetPrevisaoDoTempo(cidadeEntry.Text);

                    
                    //Console.WriteLine(previsaoDoTempo.ToString());
                    
                    this.BindingContext = previsaoDoTempo;
                    btnPrevisao.Text = "Nova Previsao";
                }
            } 
            catch (Exception ex)
            {
                await DisplayAlert("Erro aqui", ex.Message, "OK");

            }

        }
    }
}
