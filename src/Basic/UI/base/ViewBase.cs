namespace IJKD.dotNetFramework.Example.UI
{
    using System;

    public abstract class ViewBase
    {
        public string Title { get; set; }
        
        //public string Text { get; set; }

        //public abstract void Render();

        public ViewBase ParentView { get; set; }

        public abstract void Show();
        
        public virtual void Close()
        {
            Console.Clear();
            ParentView.Show();
        }
    }
}
