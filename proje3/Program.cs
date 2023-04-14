using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Xml.Linq;

namespace proje3
{
    class Program
    {
        class WordTreeNode
        {
            public string data;
            public int count;
            public WordTreeNode leftChild;
            public WordTreeNode rightChild;
            public void displayNode() { Console.Write(" Kelime: " + data + " İçerme sayısı: "+(count+1)+"\n"); }
        }
        class WordTree
        {
            public WordTreeNode root;
            public int sayi;

            public WordTree() { root = null; }

            public WordTreeNode getRoot()
            { return root; }

            // Agacın preOrder Dolasılması
            public void preOrder(WordTreeNode localRoot)
            {
                if (localRoot != null)
                {
                    localRoot.displayNode();
                    preOrder(localRoot.leftChild);
                    preOrder(localRoot.rightChild);
                }
            }

            // Agacın inOrder Dolasılması
            public void inOrder(WordTreeNode localRoot)
            {
                if (localRoot != null)
                {
                    inOrder(localRoot.leftChild);
                    localRoot.displayNode();
                    inOrder(localRoot.rightChild);
                }
            }

            // Agacın postOrder Dolasılması
            public void postOrder(WordTreeNode localRoot)
            {
                if (localRoot != null)
                {
                    postOrder(localRoot.leftChild);
                    postOrder(localRoot.rightChild);
                    localRoot.displayNode();
                }
            }

            // Agaca bir dügüm eklemeyi saglayan metot
            public void insert(string newdata)
            {
                
                WordTreeNode newNode = new WordTreeNode();
                newNode.data = newdata;
                if (root == null)
                    root = newNode;
                else
                {
                    WordTreeNode current = root;
                    WordTreeNode parent;
                    
                    while (true)
                    {
                        parent = current;
                        bool result = newdata.Equals(parent.data, StringComparison.OrdinalIgnoreCase);
                        bool areEqual = String.Equals(newdata, parent.data, StringComparison.OrdinalIgnoreCase);
                        int comparison = String.Compare(newdata, parent.data, comparisonType: StringComparison.OrdinalIgnoreCase);
                        if (comparison<0)
                        {
                            current = current.leftChild;
                            if (current == null)
                            {
                                parent.leftChild = newNode;
                                parent.leftChild.count = 0;
                                return;
                            }
                        }
                        else if (comparison == 0)
                        {
                            parent.count++;
                            return;
                        }
                        else
                        {
                            current = current.rightChild;
                            if (current == null)
                            {
                                parent.rightChild = newNode;
                                parent.rightChild.count = 0;
                                return;
                            }
                        }
                    } // end while
                } // end else not root
            } // end insert()
        }
        public class MaxHeap
        {
            private readonly MilliPark[] _elements;
            private int _size;

            public MaxHeap(int size)
            {
                _elements = new MilliPark[size];
            }

            private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
            private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
            private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

            private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
            private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
            private bool IsRoot(int elementIndex) => elementIndex == 0;

            private MilliPark GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
            private MilliPark GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
            private MilliPark GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

            private void Swap(int firstIndex, int secondIndex)
            {
                var temp = _elements[firstIndex];
                _elements[firstIndex] = _elements[secondIndex];
                _elements[secondIndex] = temp;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public MilliPark Peek()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                return _elements[0];
            }

            public MilliPark Pop()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                var result = _elements[0];
                _elements[0] = _elements[_size - 1];
                _size--;

                ReCalculateDown();

                return result;
            }

            public void Add(MilliPark element)
            {
                if (_size == _elements.Length)
                    throw new IndexOutOfRangeException();

                _elements[_size] = element;
                _size++;

                ReCalculateUp();
            }

            private void ReCalculateDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    var biggerIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && GetRightChild(index).Yuzolcumu > GetLeftChild(index).Yuzolcumu)
                    {
                        biggerIndex = GetRightChildIndex(index);
                    }

                    if (_elements[biggerIndex].Yuzolcumu < _elements[index].Yuzolcumu)
                    {
                        break;
                    }

                    Swap(biggerIndex, index);
                    index = biggerIndex;
                }
            }

            private void ReCalculateUp()
            {
                var index = _size - 1;
                while (!IsRoot(index) && _elements[index].Yuzolcumu > GetParent(index).Yuzolcumu)
                {
                    var parentIndex = GetParentIndex(index);
                    Swap(parentIndex, index);
                    index = parentIndex;
                }
            }
        }


            class TreeNode
        {

            public MilliPark data;
            public TreeNode leftChild;
            public TreeNode rightChild;
            public void displayNode() { Console.Write(" " + data + " "); }
        }
        class Tree
        {
            private TreeNode root;
            public MilliPark mp;

            public Tree() { root = null; }

            public TreeNode getRoot()
            { return root; }

            // Agacın preOrder Dolasılması
            public void preOrder(TreeNode localRoot)
            {
                if (localRoot != null)
                {
                    localRoot.displayNode();
                    preOrder(localRoot.leftChild);
                    preOrder(localRoot.rightChild);
                }
            }
            public double ifBalanced(int nodeNumber)
            {
                return Math.Ceiling(Math.Log(nodeNumber, 2));
            }
            int maxDepth(TreeNode node)
            {
                if (node == null)
                    return 0;
                else
                {
                    /* compute the depth of each subtree */
                    int lDepth = maxDepth(node.leftChild);
                    int rDepth = maxDepth(node.rightChild);

                    /* use the larger one */
                    if (lDepth > rDepth)
                        return (lDepth + 1);
                    else
                        return (rDepth + 1);
                }
            }
            int totalNodes(TreeNode root)
            {
                if (root == null)
                    return 0;

                int l = totalNodes(root.leftChild);
                int r = totalNodes(root.rightChild);

                return 1 + l + r;
            }
            // Agacın inOrder Dolasılması
            public void inOrder(TreeNode localRoot)
            {
                if (localRoot != null)
                {
                    inOrder(localRoot.leftChild);
                    localRoot.displayNode();
                    inOrder(localRoot.rightChild);
                }
            }

            // Agacın postOrder Dolasılması
            public void postOrder(TreeNode localRoot)
            {
                if (localRoot != null)
                {
                    postOrder(localRoot.leftChild);
                    postOrder(localRoot.rightChild);
                    localRoot.displayNode();
                }
            }
            public void düzeyListele(TreeNode etkin, int d)
            {
                if (etkin != null)
                {
                    d = d + 1;
                    düzeyListele(etkin.leftChild, d);
                    if ((etkin.leftChild == null) && (etkin.rightChild == null))
                        Console.WriteLine(" " + etkin.data + " " + d + ". düzeyde");
                    düzeyListele(etkin.rightChild, d);
                }
            }
            public TreeNode rfind(TreeNode etkin, string aranan)
            {
                if (etkin == null) return null;
                int comparison = String.Compare(etkin.data.Ad.Substring(0, 3), aranan, comparisonType: StringComparison.OrdinalIgnoreCase);
                if (comparison<0)
                    return rfind(etkin.leftChild, aranan);
                else
                if (comparison>0)
                    return rfind(etkin.rightChild, aranan);
                else return etkin;
            }
            public void traverse(TreeNode root,WordTree wt)
            {
                if (root.leftChild != null)
                {
                    traverse(root.leftChild,wt);
                }
                foreach (string i in root.data.Bilgi)
                {
                    wt.insert(i);
                }
                if (root.rightChild != null)
                {
                    traverse(root.rightChild,wt);
                }
            }


            // Agaca bir dügüm eklemeyi saglayan metot

            public void insert(MilliPark newdata)
            {

                TreeNode newNode = new TreeNode();
                newNode.data = newdata;
                if (root == null)
                    root = newNode;
                else
                {
                    TreeNode current = root;
                    TreeNode parent;
                    while (true)
                    {
                        parent = current;
                        string root = parent.data.Ad;
                        string root2 = newdata.Ad;

                        bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
                        bool areEqual = String.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
                        int comparison = String.Compare(root, root2, comparisonType: StringComparison.OrdinalIgnoreCase);
                        if (comparison > 0)
                        {
                            current = current.leftChild;
                            if (current == null)
                            {
                                parent.leftChild = newNode;
                                return;
                            }
                        }
                        else
                        {
                            current = current.rightChild;
                            if (current == null)
                            {
                                parent.rightChild = newNode;
                                return;
                            }
                        }
                    } // end while
                } // end else not root
            } // end insert()



            public static void Main(string[] args)
            {
                Tree agac = new Tree();
                Hashtable ht = new Hashtable(48);
                MaxHeap mh = new MaxHeap(48);

                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\milliPark.txt"))
                    {
                        string line;

                        // Read and display lines from the file until the end of
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] ozellikler = line.Split(';');
                            MilliPark mp = new MilliPark(ozellikler[0], ozellikler[1], Convert.ToInt32(ozellikler[3]), ozellikler[2], ozellikler[4]);
                            agac.insert(mp);
                            ht.Add(mp.Ad, mp);
                            mh.Add(mp);



                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

                agac.inOrder(agac.getRoot());
                Console.WriteLine("Ağacın max derinliği: " + agac.maxDepth(agac.getRoot()));
                Console.WriteLine("Ağaçtaki düğüm sayısı: "+agac.totalNodes(agac.getRoot()));
                Console.WriteLine("Ağaç dengeli olsaydı derinliği "+agac.ifBalanced(agac.totalNodes(agac.getRoot()))+" olurdu");
                Console.WriteLine("Bulmak istediğiniz milli parkın adının ilk 3 harfini giriniz: ");

                
                WordTree wt = new WordTree();
                agac.traverse(agac.getRoot(), wt);
                string isim = Console.ReadLine();
                Console.WriteLine(agac.rfind(agac.getRoot(),isim).data);
                wt.inOrder(wt.getRoot());
                foreach(string i in ht.Keys)
                {
                    Console.WriteLine(ht[i]);
                }
                Console.WriteLine("Hashtableda ilan tarihini güncellemek istediğiniz milli parkın adını giriniz:");
                isim = Console.ReadLine();
                Console.WriteLine("Yeni tarihi gün.ay.yıl şeklinde giriniz: ");
                string tarih = Console.ReadLine();
                MilliPark q = (MilliPark)ht[isim];
                MilliPark park = new MilliPark(q.Ad, q.Il, q.Yuzolcumu, tarih, q.Bilgiler);
                ht[isim] = park;
                Console.WriteLine(ht[isim]);
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(mh.Pop());
                }
                

            }
        }

    }
}