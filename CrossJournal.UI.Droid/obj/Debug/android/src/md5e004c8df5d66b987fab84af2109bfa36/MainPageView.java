package md5e004c8df5d66b987fab84af2109bfa36;


public class MainPageView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CrossJournal.UI.Droid.Views.MainPageView, CrossJournal.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainPageView.class, __md_methods);
	}


	public MainPageView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainPageView.class)
			mono.android.TypeManager.Activate ("CrossJournal.UI.Droid.Views.MainPageView, CrossJournal.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
