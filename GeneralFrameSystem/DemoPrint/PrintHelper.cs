using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrint
{
    /// <summary>
    /// 打印帮助类
    /// </summary>
    public class PrintHelper
    {
        #region constructor and properties

        /// <summary>
        /// 需要打印的内容
        /// </summary>
        public List<PrintInfo> PrintInfos { get; set; }

        public PrintHelper() {

        }

        #endregion

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="g"></param>
        public void Print(Graphics g)
        {
            if (this.PrintInfos != null && this.PrintInfos.Count > 0)
            {
                foreach (PrintInfo p in this.PrintInfos)
                {
                    switch (p.PrtType)
                    {
                        case PrintType.Text:
                            Font tFont = new Font("Arial", p.Size, p.FontStyle);
                            Brush b = new SolidBrush(p.PrtColor);
                            g.DrawString(p.Content, tFont, b, p.Start);
                            break;
                        case PrintType.Table:
                            float distance_h = (p.End.Y-p.Start.Y)*1.0f / p.Row;//横线之间的间距
                            float distance_w = (p.End.X-p.Start.X)*1.0f / p.Column;//竖线之间的间距
                            Pen lineColor = new Pen(p.PrtColor, 0.2f);
                            for (int i = 0; i < p.Row+1; i++)
                            {
                                //画横线
                                float y = p.Start.Y + (i) * distance_h;
                                g.DrawLine(lineColor, new PointF(p.Start.X, y), new PointF(p.End.X, y));
                            }
                            for (int i = 0; i < p.Column+1; i++)
                            {
                                //画竖线
                                float x = p.Start.X + (i) * distance_w;
                                g.DrawLine(lineColor, new PointF(x, p.Start.Y), new PointF(x, p.End.Y));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    public class PrintInfo {

        /// <summary>
        /// 打印类型
        /// </summary>
        public PrintType PrtType { get; set; }

        /// <summary>
        /// 打印颜色
        /// </summary>
        public Color PrtColor { get; set; }

        /// <summary>
        /// 起始位置
        /// </summary>
        public Point Start { get; set; }

        /// <summary>
        /// 结束位置
        /// </summary>
        public Point End { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public int Size { get; set; }

        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// 打印内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 列数
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int Row { get; set; }
    }

    /// <summary>
    /// 打印类型
    /// </summary>
    public enum PrintType
    {
        Text = 0,
        Table = 1,

    }
}
