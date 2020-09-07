/*--------------------------------------------------
* TickerDemo.java
*-------------------------------------------------*/

import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;

public class MainformMIDlet extends MIDlet implements CommandListener
{
public Display display;// Reference to Display object
private Display display2;
public List lsProducts;// Main productlist
private Ticker tkSale;// Ticker of what's on sale
private Command cmExit;// Command to exit the MIDlet
private Command cmClick;
private Command cmBack;
public Form form;
public Image cover;
public ImageItem imageItem;
public MainformMIDlet()
{
display= Display.getDisplay(this);
cmClick=new Command("Выбрать", Command.OK,1);
cmExit=new Command("Выход", Command.EXIT,2);
lsProducts=new List("Счетчик времени", Choice.IMPLICIT);
lsProducts.append("Статистика",null);
lsProducts.append("Настройки",null);
lsProducts.append("О приложении",null);
lsProducts.addCommand(cmExit);
lsProducts.addCommand(cmClick);
lsProducts.setCommandListener(this);
}


public void startApp()
{
display.setCurrent(lsProducts);
}
public void pauseApp()
{
}
public void destroyApp(boolean unconditional)
{
}
public void commandAction(Command c, Displayable s)
{
if(c== cmExit)
{
destroyApp(true);
notifyDestroyed();
}
if(c==cmClick) {
	if(lsProducts.getSelectedIndex() == 0) {
	CanvasOne Canv = new CanvasOne();
	Canv.setCommandListener(this);
	cmBack=new Command("Назад", Command.BACK,0);
	Canv.addCommand(cmBack);
	display.setCurrent(Canv);
	}
	if(lsProducts.getSelectedIndex() == 1){
	Alert underConstruction = new Alert("Ошибка", "Эта функция скоро будет в разработке.", null, AlertType.ERROR);
	display.setCurrent(underConstruction);
	underConstruction.setTimeout(5000);
	}
	if(lsProducts.getSelectedIndex() == 2) {

	form = new Form("О приложении");
	try{
	cover = Image.createImage("/cover.jpg");
	imageItem = new ImageItem(null,cover,ImageItem.LAYOUT_CENTER,"");
	form.append(imageItem);
	} catch(java.io.IOException ex) {
	form.append(new StringItem(null,"Обложка недоступна"));
	};
	StringItem str1 = new StringItem(null, "Счетчик времени Tinelix для J2ME");
	StringItem str2 = new StringItem(null, "\n\nВерсия 1.5.0 для J2ME (September 2020)\n\n© 2020 Tinelix. Все права защищены.");
	form.append(str1);
	form.append(str2);
	form.setCommandListener(this);
	cmBack=new Command("Назад", Command.BACK,0);
	form.addCommand(cmBack);
	display.setCurrent(form);
	}
}
if(c==cmBack){
	display.setCurrent(lsProducts);
}
}
}
