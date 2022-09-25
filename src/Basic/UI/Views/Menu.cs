namespace IJKD.dotNetFramework.Example.UI.Views
{
    using System;
    using System.Collections.Generic;

    public class Menu : ViewBase
    {
        private const char _startLetter = 'a';
        private const char _backLetter = '\b'; // backspace
        private const string _itemPadding = "   ";
        private ConsoleColor _titleColor = ConsoleColor.White;
        private ConsoleColor _itemColor = ConsoleColor.Gray;
        private ConsoleColor _defaultForegroundColor = Console.ForegroundColor;

        public Menu()
        {
            SubViews = new List<ViewBase>();
        }

        public IList<ViewBase> SubViews { get; private set; }

        public void AddSubView(ViewBase view)
        {
            SubViews.Add(view);
            view.ParentView = this;
        }

        public override void Show()
        {
            bool isRootMenu = ParentView == null;

            do
            {
                var goBack = false;
                do
                {
                    ShowMenu();

                    int viewIndex = -1;
                    var key = Char.MinValue;
                    var itemChoosed = false;

                    do
                    {
                        key = Console.ReadKey().KeyChar;
                        viewIndex = GetViewIndex(key);
                        itemChoosed = viewIndex >= 0 && viewIndex < SubViews.Count;
                        goBack = key == _backLetter;

                    } while (!itemChoosed && !goBack);

                    if (itemChoosed)
                    {
                        SubViews[viewIndex].Show();
                    }
                } while (!goBack);

            } while (isRootMenu);
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = _titleColor;
            Console.WriteLine(Title);
            Console.ForegroundColor = _defaultForegroundColor;
            Console.WriteLine();

            ShowMenuRows();
            Console.WriteLine();
        }

        private int GetViewIndex(char key)
        {
            return Convert.ToInt32(key) - Convert.ToInt32(_startLetter);
        }

        private void ShowMenuRows()
        {
            for (int i = 0; i < SubViews.Count; i++)
            {
                var letter = Convert.ToChar(Convert.ToInt32(_startLetter) + i);

                Console.ForegroundColor = _itemColor;
                Console.WriteLine("{0}{1}) {2}", _itemPadding, letter, SubViews[i].Title);
                Console.ForegroundColor = _defaultForegroundColor;
            }
        }
    }
}
