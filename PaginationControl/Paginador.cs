
namespace PaginationControl
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Paginador : UserControl
    {


        #region Properties and variables


        private bool _WhithBody;
        public bool WhithBody
        {
            get
            {
                return _WhithBody;
            }

            set
            {
                _WhithBody = value;

                if (_WhithBody)
                {
                    this.BackColor = Color.Transparent;
                    this.BackgroundImage = Properties.Resources.Body;
                }
                else
                {
                    this.BackColor = Color.White;
                    this.BackgroundImage = null;
                }
            }
        }



        private Color _ChangeOptionColor = Color.Transparent;
        public Color ChangeOptionColor
        {
            get
            {
                return _ChangeOptionColor;
            }

            set
            {
                _ChangeOptionColor = value;

                BTRigth.BackColor = _ChangeOptionColor;
                BTLeft.BackColor = _ChangeOptionColor;
            }
        }



        private Color _ColorUnselected = Color.Transparent;
        public Color ColorUnselected
        {
            get
            {
                return _ColorUnselected;
            }

            set
            {
                _ColorUnselected = value;

                BTTwo.BackColor = _ColorUnselected;
                BTTree.BackColor = _ColorUnselected;
                BTFor.BackColor = _ColorUnselected;
                BTFive.BackColor = _ColorUnselected;
            }
        }



        private Color _OpcionColor = Color.SkyBlue;
        public Color OpcionColor
        {
            get
            {
                return _OpcionColor;
            }

            set
            {
                _OpcionColor = value;

                BTOne.BackColor = _OpcionColor;
            }
        }



        public string TextPaginationEmpty
        {
            get
            {
                return _TextPaginationEmpty.Text;
            }

            set
            {
                _TextPaginationEmpty.Text = value;
            }
        }



        public Color EmptyPaginationTextColor
        {
            get
            {
                return _TextPaginationEmpty.ForeColor;
            }

            set
            {
                _TextPaginationEmpty.ForeColor = value;
            }
        }



        private int? _Pag = 0;
        public int Pag
        {
            get
            {
                return _Pag.Value;
            }

            set
            {
                _Pag = value;

                if (_Pag != null)
                {
                    BTOne.BackColor = _OpcionColor;

                    if (_Pag == 1)
                    {
                        BTTwo.Visible = false;
                        BTTree.Visible = false;
                        BTFor.Visible = false;
                        BTFive.Visible = false;

                        BTRigth.Visible = false;
                        BTLeft.Enabled = false;
                    }
                    else if (_Pag == 2)
                    {
                        BTRigth.Location = new System.Drawing.Point(100, 3);

                        BTTwo.Visible = true;

                        BTTree.Visible = false;
                        BTFor.Visible = false;
                        BTFive.Visible = false;

                        BTRigth.Visible = true;
                        BTLeft.Enabled = true;
                    }
                    else if (_Pag == 3)
                    {
                        BTRigth.Location = new System.Drawing.Point(132, 3);

                        BTTree.Visible = true;

                        BTFor.Visible = false;
                        BTFive.Visible = false;

                        BTRigth.Visible = true;
                        BTLeft.Enabled = true;
                    }
                    else if (_Pag == 4)
                    {
                        BTRigth.Location = new System.Drawing.Point(164, 3);

                        BTFor.Visible = true;

                        BTFive.Visible = false;

                        BTRigth.Visible = true;
                        BTLeft.Enabled = true;
                    }
                    else if (_Pag >= 5)
                    {
                        BTRigth.Location = new System.Drawing.Point(196, 3);

                        BTFive.Visible = true;

                        BTRigth.Visible = true;
                        BTLeft.Enabled = true;
                    }

                    this.Width = BTRigth.Location.X + BTRigth.Width + 4;
                }
            }
        }



        private Func<int, int> _ShowWhithPagination;
        public Func<int, int> ShowWhithPagination
        {
            private get
            {
                return null;
            }

            set
            {
                _ShowWhithPagination = value;

                ResettingButtons();
                MarkBT(BTOne);
                ChangePage(1, _ShowWhithPagination);

            }
        }


        #endregion


        public Paginador()
        {
            InitializeComponent();

            this.MinimumSize = new Size(229, 31);
            this.MaximumSize = new Size(229, 31);

            _TextPaginationEmpty.Location = new Point(this.Width / 2 - _TextPaginationEmpty.Width / 2, this.Height / 2 - _TextPaginationEmpty.Height / 2);
        }


        #region Event click of the buttons

        private void BTOne_Click(object sender, EventArgs e)
        {
            MarkBT(sender);
            ChangePage(int.Parse(((Button)sender).Text), _ShowWhithPagination);
        }

        #endregion


        /// <summary>
        /// Metodo que se encarga de margar el boton seleccionado
        /// </summary>
        /// <param name="sender">Un objeto de tipo boton que a sido selecionado</param>
        public void MarkBT(object sender)
        {
            BTOne.BackColor = _ColorUnselected;
            BTTwo.BackColor = _ColorUnselected;
            BTTree.BackColor = _ColorUnselected;
            BTFor.BackColor = _ColorUnselected;
            BTFive.BackColor = _ColorUnselected;

            ((Button)sender).BackColor = _OpcionColor;
        }


        /// <summary>
        /// Evento click del boton que marca hacia la izquierda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTLeft_Click(object sender, EventArgs e)
        {
            CheckMarkLeft();
        }

        /// <summary>
        /// Evento click del boton que marca hacia la derecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTRigth_Click(object sender, EventArgs e)
        {
            CheckMarkRigth();
        }


        /// <summary>
        /// Método que efectúa el cambio de botón hacia la derecha.
        /// </summary>
        private void CheckMarkRigth()
        {
            if (BTOne.BackColor == _OpcionColor)
            {
                MarkBT(BTTwo);

                ChangePage(int.Parse(BTTwo.Text), _ShowWhithPagination);
            }
            else if (BTTwo.BackColor == _OpcionColor)
            {
                MarkBT(BTTree);

                ChangePage(int.Parse(BTTree.Text), _ShowWhithPagination);
            }
            else if (BTTree.BackColor == _OpcionColor)
            {
                MarkBT(BTFor);

                ChangePage(int.Parse(BTFor.Text), _ShowWhithPagination);
            }
            else if (BTFor.BackColor == _OpcionColor)
            {
                MarkBT(BTFive);

                ChangePage(int.Parse(BTFive.Text), _ShowWhithPagination);
            }
            else if (BTFive.BackColor == _OpcionColor)
            {
                if (_Pag > 5 && int.Parse(BTFive.Text) < _Pag)
                {
                    BTFive.Text = (int.Parse(BTFive.Text) + 1).ToString();
                    BTFor.Text = (int.Parse(BTFor.Text) + 1).ToString();
                    BTTree.Text = (int.Parse(BTTree.Text) + 1).ToString();
                    BTTwo.Text = (int.Parse(BTTwo.Text) + 1).ToString();
                    BTOne.Text = (int.Parse(BTOne.Text) + 1).ToString();
                }

                ChangePage(int.Parse(BTFive.Text), _ShowWhithPagination);
            }
        }

        /// <summary>
        /// Método que efectúa el cambio de botón hacia la izquierda.
        /// </summary>
        private void CheckMarkLeft()
        {
            if (BTOne.BackColor == _OpcionColor)
            {
                if (int.Parse(BTOne.Text) > 1)
                {
                    BTFive.Text = (int.Parse(BTFive.Text) - 1).ToString();
                    BTFor.Text = (int.Parse(BTFor.Text) - 1).ToString();
                    BTTree.Text = (int.Parse(BTTree.Text) - 1).ToString();
                    BTTwo.Text = (int.Parse(BTTwo.Text) - 1).ToString();
                    BTOne.Text = (int.Parse(BTOne.Text) - 1).ToString();
                }

                ChangePage(int.Parse(BTOne.Text), _ShowWhithPagination);
            }
            else if (BTTwo.BackColor == _OpcionColor)
            {
                MarkBT(BTOne);

                ChangePage(int.Parse(BTOne.Text), _ShowWhithPagination);
            }
            else if (BTTree.BackColor == _OpcionColor)
            {
                MarkBT(BTTwo);

                ChangePage(int.Parse(BTTwo.Text), _ShowWhithPagination);
            }
            else if (BTFor.BackColor == _OpcionColor)
            {
                MarkBT(BTTree);

                ChangePage(int.Parse(BTTree.Text), _ShowWhithPagination);
            }
            else if (BTFive.BackColor == _OpcionColor)
            {
                MarkBT(BTFor);

                ChangePage(int.Parse(BTFor.Text), _ShowWhithPagination);
            }

        }


        /// <summary>
        /// Mestodo que verifica las paginas generadas.
        /// </summary>
        /// <param name="pag">Pagina que se desea trael de la base de datos.</param>
        /// <param name="_ShowWhithPagination">Metodo que se encarga de trael los datos de la base de datos y retornar el numero de paginas.</param>
        private void ChangePage(int pag, Func<int, int> _ShowWhithPagination)
        {
            var pages = _ShowWhithPagination(pag);

            if (pages == 0)
            {
                ComponentVisible(false);
            }
            else
            {
                ComponentVisible(true);

                _Pag = pages;
            }
        }

        /// <summary>
        /// Este metodo ayuda a mostar u ocurtar los componentes.
        /// </summary>
        /// <param name="enabel"></param>
        private void ComponentVisible(bool enabel)
        {
            BTOne.Visible = enabel;
            BTTwo.Visible = enabel;
            BTTree.Visible = enabel;
            BTFor.Visible = enabel;
            BTFive.Visible = enabel;

            BTLeft.Visible = enabel;
            BTRigth.Visible = enabel;

            _TextPaginationEmpty.Visible = !enabel;
        }

        /// <summary>
        /// Reninicia los botones a su valor predeterminado
        /// </summary>
        private void ResettingButtons()
        {
            BTOne.Text = "1";
            BTTwo.Text = "2";
            BTTree.Text = "3";
            BTFor.Text = "4";
            BTFive.Text = "5";
        }


        #region Eventos para efectos de los botones


        private void BTLeft_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.System;
        }

        private void BTLeft_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Flat;
        }


        #endregion

    }
}
