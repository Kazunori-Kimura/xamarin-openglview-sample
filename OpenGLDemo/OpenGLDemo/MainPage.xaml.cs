﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenGLDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Title = "main";

            PushOpenGLView.Clicked += async (s, a) =>
            {
                await Navigation.PushAsync(new OpenGLPage());
            };
		}
	}
}
