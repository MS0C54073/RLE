using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.IO.Compression;
using Ionic.Zip;

namespace RLE
{
    public partial class Form1 : Form
    {
        public string file_path;
        public string file_name;
        public string file_ext;
        public Form1()
        {
            InitializeComponent();
        }

        private void cbx_set_pass_CheckedChanged(object sender, EventArgs e)
        {
            // При изменении чекбокса "задать пароль" отображать поля для ввода пароля
            if(cbx_set_pass.Checked == true)
            {
                    tbx_pass.Visible = true;
                lbl_set_pass.Visible = true;
            }
            else {
                tbx_pass.Visible = false;
                lbl_set_pass.Visible = false;
            }
        }

        private void btn_set_file_Click(object sender, EventArgs e)
        {
            // Пустые значения
            var fileContent = string.Empty;
            var filePath = string.Empty;

            // вызываем диалоговое окно выбора файла для архивации
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; //начинаем с корня
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; // позволяем выбирать отдельно текстовые файлы

                // разрешаем действия с папками в диалоговом окне
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // записываем путь к выбранному файлу
                    filePath = openFileDialog.FileName;
                }
            }

            // отображаем кнопку "Архивация" и помечаем, что файл выбран
            file_path = filePath;
            lbl_file_path.Text = "Файл выбран";
            btn_start_rle.Enabled = true;
            
        }

        private void btn_start_rle_Click(object sender, EventArgs e)
        {
            lbl_result.Visible = true; // Отображение элементов
            pgb_archive.Visible = true; // Отображение элементов
            string str = System.IO.File.ReadAllText(file_path); // Считываем из исходного файла всё
            string result_line = ""; // результат кодирования
            string startPath = file_path; // начальный путь для архивации
            string zipPath = ""; // путь к архиву
            int fragments = 1; // количество частей архива

            if (rb_rle.Checked) // Если выбран метод RLE
            {
                int counter = 0; // счетчик
                char symbol; // проверяемый символ

                symbol = str[0]; // изначально он равен первому
                for (int i = 0; i < str.Length; i++) // проходим по всем символам файла
                {

                    if (str[i] >= 'a' && str[i] <= 'z') // если этот символ - буква
                    {
                        if (str[i] == symbol) // и она равна предыдущей
                        {
                            if (counter == 9) // и счетчик не переполнен
                            {
                                result_line += counter.ToString() + symbol.ToString(); // записываем промежуточный символ
                                counter = 0; // сбрасываем счетчик
                            }
                            counter++; // то увеличиваем значение счетчика
                        }
                        else
                        {
                            result_line += counter.ToString() + symbol.ToString(); // записываем символ
                            symbol = str[i]; // присваиваем его значение переменной
                            counter = 1; // задаём счетчику единицу
                        }
                    }
                    else if (str[i] == '\n') // если символ - перевод строки
                    {
                        result_line += counter.ToString() + symbol.ToString(); 
                        result_line += "!"; // преобразовываем его в восклицательный знак
                        counter = 0;
                        symbol = str[i + 1]; // и переходим к следующему
                    }

                    // сдвиг прогрессбара
                    pgb_archive.Value = Convert.ToInt32(100 * i / str.Length);
                    if (i == str.Length - 1) { pgb_archive.Value = 100; }
                }

            }


            if (rb_btw.Checked) // Если метод Барроуза-Уиллера
            {

                string str_btw = System.IO.File.ReadAllText(file_path); // считываем строки из файла

                byte[] buffer_in = Encoding.UTF8.GetBytes(str_btw); // кодируем их на входные параметры
                byte[] buffer_out = new byte[buffer_in.Length]; 
                byte[] buffer_decode = new byte[buffer_in.Length];

                BWTImplementation bwt = new BWTImplementation(); // создаем класс, реализующий методы преобразования

                int primary_index = 0;
                bwt.bwt_encode(buffer_in, buffer_out, buffer_in.Length, ref primary_index); // операция кодирования
                bwt.bwt_decode(buffer_out, buffer_decode, buffer_in.Length, primary_index); // операция декодирования

                result_line = Encoding.UTF8.GetString(buffer_out); // ввод результата в переменную
                pgb_archive.Value = 100;

            }

            // HF

            if (rb_hf.Checked) // Если метод энтропийного кодирования
            {
                HuffmanTree huffmanTree = new HuffmanTree(); // Создаём экземпляр класса

                huffmanTree.Build(str); // строим дерево кодирования внутренним методом

                BitArray encoded = huffmanTree.Encode(str);
                string str_res = "";
                foreach (bool bit in encoded) // перебираем все комбинации 0-1
                {
                    str_res += (bit ? 1 : 0) + "";
                }
                result_line = str_res; // записываем результат
                pgb_archive.Value = 100;
            }

            if(tbx_cnt_frag == null) // если задано количество фрагментов
            {
                fragments = 1;
            } else
            {
                fragments = Convert.ToInt32(tbx_cnt_frag.Text); // считываем его
            }

            // Архивирование
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                zipPath = folderBrowserDialog1.SelectedPath; // запрашиваем у пользователя директорию для архивации
            }

            Ionic.Zip.ZipFile zf = new Ionic.Zip.ZipFile();
            for ( int k = 0; k < fragments; k++) // проходим по количеству фрагментов
            {
                zipPath = folderBrowserDialog1.SelectedPath + @"\" + (k+1).ToString() + "_Compressed.zip"; // создаём следующий архив
                zf.AddEntry((k + 1).ToString()+"compressed.txt", result_line.Substring(k * (result_line.Length / fragments), result_line.Length / fragments)); // записываем в него пропорциональное числу фрагментов число символов
                if (cbx_set_pass.Checked) { // если задан пароль
                    zf.Password = tbx_pass.Text; // Задаем и его
                }
                zf.Save(zipPath); //Сохраняем архив.
                zf.RemoveEntry((k + 1).ToString()+"compressed.txt"); // удаляем из коллекции файл с частью кода
            }
            

            if (cbx_del_files.Checked) // если выбрана опция "удалить исходный файл"
            {
                System.IO.File.Delete(file_path); // удаляем его
            }

        }

        private void btn_get_archive_Click(object sender, EventArgs e)
        {
            // пустые переменные
            var fileContent = string.Empty;
            var fp = string.Empty;

            string encode_str;
            string str = "";
            bool fl = true;
            Ionic.Zip.ZipFile zf = new Ionic.Zip.ZipFile(fp); // заранее создаем экземпляр класса для работы с архивами

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
                // открываем диалог выбора архива
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fp = openFileDialog.FileName; // записываем имя файла

                    if (fp.Substring(fp.LastIndexOf("\\") + 1, 1) == "1") // проверяем, первый ли архив выбран
                    {
                        for (int p = 1; p <= 10; p++) // проверяем 10 фрагментов (опционально)
                        {
                            if (File.Exists(fp.Substring(0, fp.LastIndexOf("\\")) + "\\" + p.ToString() + "_Compressed.zip")) // если этот архив существует, идём к проверке следующего
                            {
                                zf = new Ionic.Zip.ZipFile(fp.Substring(0, fp.LastIndexOf("\\")) + "\\" + p.ToString() + "_Compressed.zip"); // вгружаем его в класс
                                zf.ExtractAll(fp.Substring(0, fp.LastIndexOf("\\"))); // распаковываем в директорию
                                str += System.IO.File.ReadAllText(fp.Substring(0, fp.LastIndexOf("\\")) + "\\" + p.ToString() + "compressed.txt"); // записываем содержимое в строку

                                if (File.Exists(fp.Substring(0, fp.LastIndexOf("\\")) + "\\" + p.ToString() + "compressed.txt"))
                                {
                                    // удаляем временные файлы
                                    System.IO.File.Delete(fp.Substring(0, fp.LastIndexOf("\\")) + "\\" + p.ToString() + "compressed.txt");
                                }

                            }
                            else if (File.Exists(fp.Substring(0, fp.LastIndexOf("\\")) + "\\" + (p + 1).ToString() + "_Compressed.zip"))
                            {
                                MessageBox.Show("Архив повреждён!");
                                fl = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите первый архив!");
                    }
                }
            }

            string res_str = "";
            int j, i;

            if (fl) // если архив не поврежден
            {

                if (rb_rle_un.Checked) // смотрим, каким методом будем декодировать
                {

                    // Обратный ход метода RLE, с проверкой сначала чисел, после циклом вставки соответствующих символов
                    for (i = 0; i < str.Length-1; i++)
                    {
                        if (str[i] >= '1' && str[i] <= '9')
                        {
                            for (j = 0; j < int.Parse(str[i].ToString()); j++)
                            {
                                res_str += str[i + 1];
                            }
                            i++;
                        }
                        else if (str[i] == '!')
                        {
                            res_str += '\n';
                        }
                    }
                }

                if (rb_btw_un.Checked) // Если BWT
                {
                    // Аналогично кодированию, декодируем строку из архивов
                    byte[] buffer_in = Encoding.UTF8.GetBytes(str);
                    byte[] buffer_out = new byte[buffer_in.Length];
                    byte[] buffer_decode = new byte[buffer_in.Length];

                    BWTImplementation bwt = new BWTImplementation();
                    int primary_index = 0;
                    bwt.bwt_decode(buffer_in, buffer_decode, buffer_in.Length, primary_index);

                    res_str = Encoding.UTF8.GetString(buffer_decode);
                }

                if (rb_hf_un.Checked) // Если энтропийное, то аналогично
                {

                    HuffmanTree huffmanTree = new HuffmanTree();

                    BitArray encoded = huffmanTree.Encode(str);
                    huffmanTree.Build(str);
                    string decoded = huffmanTree.Decode(encoded);

                    res_str = decoded;
                }

                using (StreamWriter sw = new StreamWriter(fp.Substring(0, fp.LastIndexOf("\\")) + "\\uncompressed.txt", false, System.Text.Encoding.Default))
                {
                    sw.Write(res_str); // записываем результат в результирающий файл
                }

            }

        }

        private void rb_rle_un_CheckedChanged(object sender, EventArgs e)
        {
            btn_get_archive.Enabled = true;
        }

        private void rb_btw_un_CheckedChanged(object sender, EventArgs e)
        {
            btn_get_archive.Enabled = true;
        }

        private void rb_hf_un_CheckedChanged(object sender, EventArgs e)
        {
            btn_get_archive.Enabled = true;
        }
    }


    // Далее классы для реализации методов BWT  и энтропийного кодированиЯ
    class BWTImplementation
    {
        public void bwt_encode(byte[] buf_in, byte[] buf_out, int size, ref int primary_index)
        {
            int[] indices = new int[size];
            for (int i = 0; i < size; i++)
                indices[i] = i;

            Array.Sort(indices, 0, size, new BWTComparator(buf_in, size));

            for (int i = 0; i < size; i++)
                buf_out[i] = buf_in[(indices[i] + size - 1) % size];

            for (int i = 0; i < size; i++)
            {
                if (indices[i] == 1)
                {
                    primary_index = i;
                    return;
                }
            }
        }

        public void bwt_decode(byte[] buf_encoded, byte[] buf_decoded, int size, int primary_index)
        {
            byte[] F = new byte[size];
            int[] buckets = new int[0x100];
            int[] indices = new int[size];

            for (int i = 0; i < 0x100; i++)
                buckets[i] = 0;

            for (int i = 0; i < size; i++)
                buckets[buf_encoded[i]]++;

            for (int i = 0, k = 0; i < 0x100; i++)
            {
                for (int j = 0; j < buckets[i]; j++)
                {
                    F[k++] = (byte)i;
                }
            }

            for (int i = 0, j = 0; i < 0x100; i++)
            {
                while (i > F[j] && j < size - 1)
                {
                    j++;
                }
                buckets[i] = j;
            }

            for (int i = 0; i < size; i++)
                indices[buckets[buf_encoded[i]]++] = i;

            for (int i = 0, j = primary_index; i < size; i++)
            {
                buf_decoded[i] = buf_encoded[j];
                j = indices[j];
            }
        }
    }

    class BWTComparator : IComparer<int>
    {
        private byte[] rotlexcmp_buf = null;
        private int rottexcmp_bufsize = 0;

        public BWTComparator(byte[] array, int size)
        {
            rotlexcmp_buf = array;
            rottexcmp_bufsize = size;
        }

        public int Compare(int li, int ri)
        {
            int ac = rottexcmp_bufsize;
            while (rotlexcmp_buf[li] == rotlexcmp_buf[ri])
            {
                if (++li == rottexcmp_bufsize)
                    li = 0;
                if (++ri == rottexcmp_bufsize)
                    ri = 0;
                if (--ac <= 0)
                    return 0;
            }
            if (rotlexcmp_buf[li] > rotlexcmp_buf[ri])
                return 1;

            return -1;
        }
    }

    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Build(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }

            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    // Take first two items
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    // Create a parent node by combining the frequencies
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                this.Root = nodes.FirstOrDefault();

            }

        }

        public BitArray Encode(string source)
        {
            List<bool> encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            BitArray bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public string Decode(BitArray bits)
        {
            Node current = this.Root;
            string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;
                    current = this.Root;
                }
            }

            return decoded;
        }

        public bool IsLeaf(Node node)
        {
            return (node.Left == null && node.Right == null);
        }

    }

    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public List<bool> Traverse(char symbol, List<bool> data)
        {
            // Leaf
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Symbol))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.Traverse(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
