using System.Windows.Forms;
using DevExpress.Data.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraTab;
using System.Drawing;
using Bunifu.UI.WinForms;

namespace Umoxi
{
    class TransitionsEffects
    {
        public static TransitionManager transitionManager;
        //public static Control label;
        //public static BunifuLabel label;
        private static Control controlToAnimate;

        public static IEasingFunction easingFunction = new ElasticEase();


        /// <summary>
        /// Usar para dar efeitos nas transições entre forms ou controllers
        /// </summary>
        /// <param name="transition"></param>
        /// <param name="e"></param>
        public static void TransitionEffect(ITransition transition, CustomTransitionEventArgs e)
        {
            e.EasingFunction = easingFunction;
        }

       /// <summary>
       /// Controle na animação
       /// </summary>
       /// <param name="controlForUse">Deve ser implementado no controle a ser aplicado</param>
        public static void ControlEffect(Control controlForUse)
        {
            
            controlToAnimate = controlForUse;

            if (transitionManager.Transitions[controlToAnimate] == null)
            {
                Transition transition = new Transition();

                transition.Control = controlToAnimate;

                transitionManager.Transitions.Add(transition);
              

            }

            Transitions transitions = Transitions.PushFade;

            transitionManager.Transitions[controlToAnimate].TransitionType = GetTransition(transitions);
           
        }

        //Tipos de animação
        private static BaseTransition GetTransition(Transitions transitions)
        {
            switch (transitions)
            {
                case Transitions.Dissolve: return new DissolveTransition();
                case Transitions.Fade: return new FadeTransition();
                case Transitions.Shape: return new ShapeTransition();
                case Transitions.Clock: return new ClockTransition();
                case Transitions.SlideFade: return new SlideFadeTransition();
                case Transitions.Cover: return new CoverTransition();
                case Transitions.Comb: return new CombTransition();
                default: return new PushTransition();
            }
        }
        /// <summary>
        ///Aplicar a animação na control
        /// </summary>
        public static void ShowTransition(BunifuTextBox textBox, BunifuLabel labelUsed)
        {
            //label = labelUsed;
            ControlEffect(labelUsed);
            //--------------Label-------------//
            if (controlToAnimate == null)
            {
                textBox.BorderColorIdle = Color.FromArgb(222, 53, 11);
                textBox.BorderColorHover = Color.FromArgb(222, 53, 11);
                textBox.BorderColorActive = Color.FromArgb(222, 53, 11);
                labelUsed.ForeColor = Color.Red;
                textBox.Focus();
                return;
            }
            transitionManager.StartTransition(controlToAnimate);
            if (textBox.BorderColorIdle != Color.FromArgb(222, 53, 11))
            {
                textBox.BorderColorIdle = Color.FromArgb(222, 53, 11);
                textBox.BorderColorHover = Color.FromArgb(222, 53, 11);
                textBox.BorderColorActive = Color.FromArgb(222, 53, 11);
                labelUsed.ForeColor = Color.Red;
                textBox.Focus();
            }          
            transitionManager.EndTransition();
          //  transitionManager.Dispose();
        }

        /// <summary>
        /// Retira as bordas vermelhas de erro das textBox
        /// </summary>
        /// <param name="textBox">Control TextBox</param>
        /// <param name="label">Texto da control</param>
        public static void ResetColor(BunifuTextBox textBox, BunifuLabel label)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text)){ 
                textBox.BorderColorIdle = Color.Silver;
                textBox.BorderColorHover = Color.FromArgb(105, 181, 255);
                textBox.BorderColorActive = Color.FromArgb(0, 113, 188);
                label.ForeColor = Color.Black;
            }        
        }

    }
}
