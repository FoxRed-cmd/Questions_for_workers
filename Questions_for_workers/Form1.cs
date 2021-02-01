﻿using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Questions_for_workers
{
	public partial class Form1 : Form
	{
		string answers;
		string[] answers2;

		string email = "kirya.blinov.2022@mail.ru";

		string[] question = {	"Является ли дата и место составления первичного документа его обязательными реквизитами?",
								"Какой первичный документ подтверждает факт сдачи выручки в банк сотрудником компании?", "Какой документ не подписывается директором компании?",
								"Ответственность за правильность ведения операций с наличными денежными средствами в компании согласно нормативным документам несет:", 
								"В каком документе утверждены формы и системы оплаты труда, которые можно применять в компании?", 
								"Учитываются ли при расчете средней заработной платы для начисления отпускных суммы выплаченных доплат за работу в праздничные дни и премии?",
								"В конце года предприятие выплатило всем своим работникам денежное вознаграждение (13-ю зарплату). Имеет ли право предприятие включать данный вид затрат в состав валовых доходов?",
								"Предприятие «Омега» составило с банком «Гранит» договор на расчетно-кассовое обслуживание. Являются ли данные услуги объектом обложения НДС?",
								"Может ли предприятие по собственному желанию зарегистрировать себя плательщиком НДС, при условии, что размер операций по продаже товаров (работ, услуг), которые облагаются НДС, менее 3 600 необлагаемых минимумов доходов населения?",
								"Какое календарное число является датой возникновения налогового кредита для заказчика строительства, если указанное строительство осуществляется согласно долгосрочному договору?",
								"Прямые затраты — это:","Затраты на охрану труда, технику безопасности на производственном предприятии включаются в состав:",
								"Фактическая производственная себестоимость выпущенной продукции отображается в бухгалтерском учете следующей проводкой:",
								"Доходы от реализации готовой продукции отображаются в учете:", "Нажмите кнопку \"отправить\"" };

		string[] answer = {"Не для всех документов","Да","Нет",
			"Банковская выписка со штампом банка и подписью работника банка","Квитанция на внесение денежных средств с подписью кассира и бухгалтера банка, заверенная штампом банка",
			"Расходный кассовый ордер с подписью главного бухгалтера и руководителя предприятия",
			"Приходный кассовый ордер","Авансовый отчет","Расходный кассовый ордер",
			"Руководитель предприятия","Кассир","Главный бухгалтер",
			"Трудовой договор","Коллективный договор","Штатное расписание",
			"Премии учитываются, а доплаты за работу в праздничные дни — нет","Учитываются и премии, и доплаты за работу в праздничные дни","Доплаты за работу в праздничные дни учитываются, а премии — нет",
			"Да, поскольку этот вид затрат включается в фонд заработной платы","Да, при условии, что эти затраты предусмотрены в коллективном договоре","Нет, поскольку вознаграждение не включается в фонд заработной платы",
			"Да","Нет","Нет правильного ответа",
			"Да","Нет","Нет правильного ответа",
			"Дата окончания всего строительства или его этапа, определенного в договоре","Дата увеличения валовых затрат заказчика долгосрочного контракта","Нет правильного ответа",
			"Совокупность экономически однородных затрат","Затраты, которые могут быть отнесены непосредственно к конкретному объекту затрат целевым образом","Нет правильного ответа",
			"Административных затрат","Общепроизводственных затрат","Других операционных затрат",
			"Дт 91 — Кт 23","Дт 90 — Кт 26","Дт 26 — Кт 23",
			"В момент получения денег за эту продукцию или при ее отгрузке","Только в момент получения денег за эту продукцию","Только в момент отгрузки данной продукции покупателю со списанием ее стоимости с баланса компании", "n","n","n"};

		string[] true_answer = { "Во время осуществления хозяйственной операции, а если это невозможно — непосредственно после ее завершения",
			"Да","Квитанция на внесение денежных средств с подписью кассира и бухгалтера банка, заверенная штампом банка",
			"Приходный кассовый ордер","Руководитель предприятия","Коллективный договор","Учитываются и премии, и доплаты за работу в праздничные дни",
			"Да, при условии, что эти затраты предусмотрены в коллективном договоре","Нет","Да","Дата увеличения валовых затрат заказчика долгосрочного контракта",
			"Затраты, которые могут быть отнесены непосредственно к конкретному объекту затрат целевым образом","Общепроизводственных затрат","Дт 26 — Кт 23",
			"Только в момент отгрузки данной продукции покупателю со списанием ее стоимости с баланса компании"};

		int q = 0;
		int a = 0;
		int count = 0;

		public Form1()
		{
			InitializeComponent();
			label1.Text = "Укажите ФИО";
			textBox2.Text = "Когда составляется первичный документ?";
			radioButton1.Text = "Непосредственно перед осуществлением хозяйственной операции";
			radioButton2.Text = "Во время осуществления хозяйственной операции";
			radioButton3.Text = "Во время осуществления хозяйственной операции, а если это невозможно — непосредственно после ее завершения";
			button1.Text = "Ответить";
			button2.Text = "Отправить";
			button3.Text = "Сброс";
			groupBox1.Text = "Варианты ответа";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true)
			{
				answers += radioButton1.Text + ".";
			}
			else if (radioButton2.Checked == true)
			{
				answers += radioButton2.Text + ".";
			}
			else if (radioButton3.Checked == true)
			{
				answers += radioButton3.Text + ".";
			}
			textBox2.Text = question[q];
			q++;
			RadioButton[] buttons = new RadioButton[] { radioButton1, radioButton2, radioButton3 };
			foreach (var item in buttons)
			{
				item.Text = answer[a];
				a++;
			}
			foreach (var item in buttons)
			{
				if (item.Text == "n")
				{
					item.Visible = false;
					button1.Visible = false;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			answers2 = answers.Split('.');

			for (int i = 0; i < true_answer.Length; i++)
			{
				if (answers2[i] == true_answer[i])
				{
					answers2[i] += " (Верно).\r\n";
					count++;
				}
				else
				{
					answers2[i] += " (Не верно).\r\n";
				}
			}

			answers = null;

			for (int i = 0; i < answers2.Length; i++)
			{
				answers += answers2[i];
			}

			answers += $"Верных ответов: {count}/15.";

			MailAddress from = new MailAddress("testwork999@mail.ru", "Работа");
			MailAddress to = new MailAddress(email);
			using (MailMessage mailMessage = new MailMessage(from, to))
			{
				using (SmtpClient smtpClient = new SmtpClient())
				{
					mailMessage.Subject = textBox1.Text;
					mailMessage.Body = answers;
					smtpClient.Host = "smtp.mail.ru";
					smtpClient.Port = 587;
					smtpClient.EnableSsl = true;
					smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtpClient.UseDefaultCredentials = false;
					smtpClient.Credentials = new NetworkCredential(from.Address, "winterretniw999");
					smtpClient.Send(mailMessage);
				}
			}
			textBox2.Text = $"Верных ответов: {count}/15.";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}

	}
}
