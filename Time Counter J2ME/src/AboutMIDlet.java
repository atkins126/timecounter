import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;

public class AboutMIDlet extends MIDlet
{// Reference to Display object
public Form form;
public Image cover;
public ImageItem imageItem;

public AboutMIDlet()
{
form = new Form("О приложении");
try{
cover = Image.createImage("/cover.png");
imageItem = new ImageItem(null,cover,ImageItem.LAYOUT_NEWLINE_BEFORE,"");
form.append(imageItem);
} catch(java.io.IOException ex) {
form.append(new StringItem(null,"Обложка недоступна"));
};

}

public void startApp()
{
}
public void pauseApp()
{
}
public void destroyApp(boolean unconditional)
{
}

public void commandAction(Command c, Displayable s)
{

}
}