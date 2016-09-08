﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonSwitch
{
    public class ImageButton_Image : Image
    {

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<ImageButton_Image, ICommand>(p => p.Command, null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<ImageButton_Image, object>(p => p.CommandParameter, null);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {
                    this.AnchorX = 0.48;
                    this.AnchorY = 0.48;
                    //await this.ScaleTo(0.8, 50, Easing.Linear);
                    Color currentColor = this.BackgroundColor;
                    this.BackgroundColor = Color.FromHex("#B0BEC5");
                    await Task.Delay(100);
                    //await this.ScaleTo(1, 50, Easing.Linear);
                    this.BackgroundColor = currentColor;
                    if (Command != null)
                    {
                        Command.Execute(CommandParameter);
                    }
                });
            }
        }

        public ImageButton_Image()
        {
            Initialize();
        }


        public void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = TransitionCommand
            });
        }

    }
}
