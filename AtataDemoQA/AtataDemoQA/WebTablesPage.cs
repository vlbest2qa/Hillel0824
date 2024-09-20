using _ = AtataDemoQA.WebTablesPage;

namespace AtataDemoQA
{
    [Url("webtables")]
    internal class WebTablesPage : Page<_>
    {
        [ScrollDown]
        [ControlDefinition("div", ContainingClass = "rt-table")]
        public Table<PeopleTableRow, _> People { get; private set; }

        [ControlDefinition("div", ContainingClass = "rt-tr-group", ComponentTypeName = "row")]
        public class PeopleTableRow : TableRow<_>
        {
            //[FindByXPath("//div[@role='gridcell'][1]")]
            [FindByCss(".rt-td:nth-of-type(1)")]
            public Text<_> FirstName { get; private set; }

            [FindByCss(".rt-td:nth-of-type(2)")]
            public Text<_> LastName { get; private set; }

            [FindByCss(".rt-td:nth-of-type(3)")]
            public Text<_> Age { get; private set; }

            [FindByCss(".rt-td:nth-of-type(4)")]
            public Text<_> Email { get; private set; }

            [FindByCss(".rt-td:nth-of-type(5)")]
            public Text<_> Salary { get; private set; }

            [FindByCss(".rt-td:nth-of-type(6)")]
            public Text<_> Department { get; private set; }

            //[FindByXPath("//span[@title='Delete']")]
            [FindByCss("span[title='Delete']")]
            public Svg<_> DeleteButton { get; private set; }

            //[FindByXPath("//span[@title='Edit']")]
            [FindByCss("span[title='Edit']")]
            public Svg<_> EditButton { get; private set; }

        }

        [FindById("addNewRecordButton")]
        public Button<_> AddNewRecordButton { get; private set; }

        //public AddPopup<_> AddPopup { get; private set; }
        /* 
         public class AddPopup<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>

         Не хочу огортати це у класс AddPopup тільки заради більчи читаємого тесту
         Коли потім у тесті все одно прийдется кожного разу до нього звертатись:
         AddPopup.FirstName.Set(firstName)
         AddPopup.LastName.Set(lastName)
         Лиш зайві строки і код. І я б до кього не додумався.
        */

        [FindById("firstName")]
        public TextInput<_> FirstName { get; private set; }

        [FindByPlaceholder("Last Name")]//чому не по ID? та просто щоб різне було=)
        public TextInput<_> LastName { get; private set; }

        [FindById("userEmail")]
        public TextInput<_> Email { get; private set; }//не зміг найти спільну мову з класом EmailInput як і з усім Atata

        [FindById("age")]
        public NumberInput<_> Age { get; private set; }

        [FindById("salary")]
        public NumberInput<_> Salary { get; private set; }

        [FindById("department")]
        public TextInput<_> Department { get; private set; }

        [FindById("submit")]
        public Button<_> Submit { get; private set; }
    }
}