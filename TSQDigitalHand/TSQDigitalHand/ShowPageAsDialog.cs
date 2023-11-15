using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TSQDigitalHand
{
    public static class ShowPageAsDialog
    {
        public static async Task showpageasdialog(this INavigation navigation, Page page)
        {
            int pagesonstack = navigation.ModalStack.Count + 1;
            var waithandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            page.Disappearing += (s, e) =>
            {
                if (navigation.ModalStack.Count < pagesonstack)
                    waithandle.Set();
            };
            await navigation.PushModalAsync(page);
            //System.Diagnostics.Debug.WriteLine(navigation.ModalStack.Count);
            await Task.Run(() => waithandle.WaitOne());
        }
    }
}
