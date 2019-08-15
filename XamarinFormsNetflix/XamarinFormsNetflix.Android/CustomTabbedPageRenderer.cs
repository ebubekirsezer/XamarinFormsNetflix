using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinFormsNetflix.CustomControls;
using XamarinFormsNetflix.Droid;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace XamarinFormsNetflix.Droid
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        bool setup;
        ViewPager pager;
        TabLayout layout;
        private Dictionary<Int32, Int64> icons = new Dictionary<Int32, Int64>();
        TabLayout currentTab;
        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }
        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            try
            {
                base.OnLayout(changed, left, top, right, bottom);
                InvertLayoutThroughScale();
            }
            catch (Exception)
            {
                return;
            }
        }
        private void InvertLayoutThroughScale()
        {
            ViewGroup.ScaleY = -1;
            TabLayout tabLayout = null;
            ViewPager viewPager = null;
            for (int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = (Android.Views.View)GetChildAt(i);
                if (view is TabLayout) tabLayout = (TabLayout)view;
                else if (view is ViewPager)
                {
                    viewPager = (ViewPager)view;
                }
            }
            tabLayout.ScaleY = viewPager.ScaleY = -1;
            tabLayout.SetPadding(0, -30, 0, 0);
            viewPager.SetPadding(0, -tabLayout.MeasuredHeight, 0, 0);
            if (currentTab != tabLayout)
            {
                for (int j = 0; j < tabLayout.TabCount; j++)
                {
                    TabLayout.Tab tab = tabLayout.GetTabAt(j);
                    tab.SetCustomView(Resource.Layout.custom_tab_layout);
                    var imageview = tab.CustomView.FindViewById<ImageView>(Resource.Id.icon);
                    var tv = tab.CustomView.FindViewById<TextView>(Resource.Id.tv);
                    tv.SetText(tab.Text, TextView.BufferType.Normal);
                    imageview.SetBackgroundDrawable(tab.Icon);
                    ColorStateList colors2 = null;
                    if ((int)Build.VERSION.SdkInt >= 23)
                    {
                        colors2 = Resources.GetColorStateList(Resource.Color.icon_tab, Forms.Context.Theme);
                    }
                    else
                    {
                        colors2 = Resources.GetColorStateList(Resource.Color.icon_tab);
                        tv.SetTextColor(colors2);
                    }
                    currentTab = tabLayout;

                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (setup)
            {
                return;
            }
            if (e.PropertyName == "Renderer")
            {
                pager = (ViewPager)ViewGroup.GetChildAt(0);
                layout = (TabLayout)ViewGroup.GetChildAt(1);
                setup = true;
                ColorStateList colors = null;
                if ((int)Build.VERSION.SdkInt >= 23)
                {
                    colors = Resources.GetColorStateList(Resource.Color.icon_tab, Forms.Context.Theme);
                }
                else
                {
                    colors = Resources.GetColorStateList(Resource.Color.icon_tab);
                }
                for (int i = 0; i < layout.TabCount; i++)
                {
                    var tab = layout.GetTabAt(i);
                    var icon = tab.Icon;
                    if (icon != null)
                    {
                        icon = Android.Support.V4.Graphics.Drawable.DrawableCompat.Wrap(icon);
                        Android.Support.V4.Graphics.Drawable.DrawableCompat.SetTintList(icon, colors);
                    }
                }
            }
        }
    }
}