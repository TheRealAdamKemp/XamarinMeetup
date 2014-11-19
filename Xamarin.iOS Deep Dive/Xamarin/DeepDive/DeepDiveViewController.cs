using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace DeepDive
{
    public partial class DeepDiveViewController : UIViewController
    {
        public DeepDiveViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

//            Button.AddTarget(this, new Selector("ButtonTapped:"), UIControlEvent.TouchUpInside);
//            Button.AddTarget(this, new Selector("ButtonTapped"), UIControlEvent.TouchUpInside);
//            Button.AddTarget((s, e) => ShowAlert(), UIControlEvent.TouchUpInside);
//            Button.TouchUpInside += (s, e) => ShowAlert();

            View.AddGestureRecognizer(new UITapGestureRecognizer(ShowAlert)
                {
                    //                    ShouldReceiveTouch = TapShouldReceiveTouch,
                    //                    Delegate = new TapGestureDelegate(this),
                    //                    WeakDelegate = this,
                    //                    Delegate = this,
                });
        }

        #region Button Handlers

        #region Action

        //        partial void ButtonTapped(UIButton sender)
        //        {
        //            ShowAlert();
        //        }

        #endregion

        #region Export with argument

        //        [Export("ButtonTapped:")]
        //        private void ButtonTapped(UIButton sender)
        //        {
        //            ShowAlert();
        //        }

        #endregion

        #region Export no argument

        [Export("ButtonTapped")]
        private void ButtonTapped()
        {
            ShowAlert();
        }

        #endregion

        #endregion

        #region Gesture Delegate

        #region Delegate

        private class TapGestureDelegate : UIGestureRecognizerDelegate
        {
            private readonly DeepDiveViewController _viewController;

            public TapGestureDelegate(DeepDiveViewController viewController)
            {
                _viewController = viewController;
            }

            public override bool ShouldReceiveTouch(UIGestureRecognizer recognizer, UITouch touch)
            {
                return _viewController.TapShouldReceiveTouch(recognizer, touch);
            }
        }

        #endregion

        #region Normal callback

        private bool TapShouldReceiveTouch(UIGestureRecognizer gesture, UITouch touch)
        {
            return RedView.HitTest(touch.LocationInView(RedView), uievent: null) != null;
        }

        #endregion

        #region Low-level callback

//        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
//        // Analysis disable once InconsistentNaming
//        public static extern IntPtr IntPtr_objc_msgSend_CGPoint_IntPtr(IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);
//
//
//        private bool TapShouldReceiveTouch(UIGestureRecognizer gesture, UITouch touch)
//        {
//            CGPoint location = touch.LocationInView(RedView);
//
//            var hitTestViewHandle = IntPtr_objc_msgSend_CGPoint_IntPtr(
//                RedView.Handle,
//                Selector.GetHandle("hitTest:withEvent:"),
//                location,
//                IntPtr.Zero);
//
//            return hitTestViewHandle != IntPtr.Zero;
//        }

        #endregion

        #endregion

        #region ShowAlert

        private void ShowAlert()
        {
            new UIAlertView("Hi!", "Hello!", null, "Howdy!").Show();
        }

        #endregion
    }
}

