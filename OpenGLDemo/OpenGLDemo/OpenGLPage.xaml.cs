using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OpenGLDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OpenGLPage : ContentPage
	{
        float red = 0f;
        float green = 0f;
        float blue = 0f;

		public OpenGLPage ()
		{
            //InitializeComponent ();
            Title = "OpenGL";

            var view = new OpenGLView {
                HasRenderLoop = true,
                HeightRequest = 300,
                WidthRequest = 300
            };
            var toggle = new Switch { IsToggled = true };
            var button = new Button { Text = "Display" };

            view.OnDisplay = (r) =>
            {
                GL.ClearColor(red, green, blue, 1f);
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                red = incr(red, 0.01f);
                green = incr(green, 0.02f);
                blue = incr(blue, 0.03f);
            };

            toggle.Toggled += (s, a) =>
            {
                view.HasRenderLoop = toggle.IsToggled;
            };

            button.Clicked += (s, a) =>
            {
                view.Display();
            };

            var stack = new StackLayout
            {
                Padding = new Size(20, 20),
                Children =
                {
                    view, toggle, button
                }
            };

            Content = stack;

		}

        private float incr(float org, float incr)
        {
            float value = org + incr;
            if (value >= 1.0f)
            {
                value -= 1.0f;
            }
            return value;
        }
	}
}