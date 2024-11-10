using System.ComponentModel;

namespace OrganizacaoFinanceira.Recursos
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => isSorted;

        protected override ListSortDirection SortDirectionCore => sortDirection;

        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)Items;
            Comparison<T> comparer = GetComparer(prop, direction);
            itemsList.Sort(comparer);

            isSorted = true;
            sortDirection = direction;
            sortProperty = prop;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortDirection = ListSortDirection.Ascending;
            sortProperty = null;
        }

        private Comparison<T> GetComparer(PropertyDescriptor prop, ListSortDirection direction)
        {
            Comparison<T> comparer = (x, y) =>
            {
                object valueX = prop.GetValue(x);
                object valueY = prop.GetValue(y);

                if (valueX == null && valueY == null)
                    return 0;
                if (valueX == null)
                    return -1;
                if (valueY == null)
                    return 1;

                int result = Comparer<object>.Default.Compare(valueX, valueY);
                return direction == ListSortDirection.Ascending ? result : -result;
            };

            return comparer;
        }

        public SortableBindingList(List<T> values = null)
        {
            if (values == null) return;

            List<T> itemsList = (List<T>)Items;
            itemsList.Clear();
            foreach (var item in values)
            {
                itemsList.Add(item);
            }
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

    }

}
