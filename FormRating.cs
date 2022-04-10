using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _0804
{
    public partial class FormRating : Form
    {
        private FormGame formGame;
        private int count;

        public FormRating(Point location, FormGame game)
        {
            InitializeComponent();
            this.Location = location;
            formGame = game;
            count = formGame.logins.Count;
        }

        private void FormRating_Load(object sender, EventArgs e)
        {
            SortStep(formGame.scores, formGame.times, formGame.logins, 0, count - 1);
            formGame.logins.Reverse();
            formGame.scores.Reverse();
            formGame.times.Reverse();
            int start = 0, end = 0;
            while (start < count - 1)
            {
                while (end + 1 < count && formGame.scores[start] == formGame.scores[end + 1]) 
                {
                    end++;
                }
                if (start != end)
                {
                    SortStep(formGame.times, formGame.scores, formGame.logins, start, end);
                }
                end++;
                start = end;
            }

            for (int i = 0; i < formGame.logins.Count; i++)
            {
                dataGridView.Rows.Add(formGame.logins[i], formGame.scores[i], 
                    Convert.ToInt32(TimeSpan.FromSeconds(formGame.times[i]).Minutes).ToString() 
                    + ":" + TimeSpan.FromSeconds(formGame.times[i]).Seconds.ToString().PadLeft(2, '0'));
            }
        }

        private static void SortStep(List<int> array, List<int> array2, List<string> array3, int start, int end)
        {
            int pivot = (start + end) / 2, start0 = start, end0 = end;
            while (start < end)
            {
                while (array[start] <= array[pivot] && start < pivot) start++;
                while (array[pivot] <= array[end] && pivot < end) end--;
                if (start == end) break;
                else
                {
                    Swap(array, start, end, array[start], array[end]);
                    Swap(array2, start, end, array2[start], array2[end]);
                    Swap(array3, start, end, array3[start], array3[end]);
                    if (start == pivot) pivot = end;
                    else if (end == pivot) pivot = start;
                }
            }
            if (pivot - start0 > 1) SortStep(array, array2, array3, start0, pivot - 1);
            if (end0 - pivot > 1) SortStep(array, array2, array3, pivot + 1, end0);
        }

        private static void Swap(List<string> array, int i1, int i2, string value1, string value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }

        static void Swap(List<int> array, int i1, int i2, int value1, int value2)
        {
            array[i1] = value2;
            array[i2] = value1;
        }
    }
}
