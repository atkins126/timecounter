import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import java.*;

public class CanvasOne extends Canvas
{

// ѕолучаем Ўирину и ¬ысоту экрана соответственно (не всегда работает верно!!!)
    
    private int w = getWidth();
    private int h = getHeight();

	private Command cmExit;
	private Display display;

// –еализуем метод paint(), который и быдет прорисовывать нашу строку =)

    protected void paint(Graphics g) {

// –исуем строку "Hello World!", —редняя верхняя точка которой
// расположена в точке (w/2+1, h/3+1) (фон)

		
		java.util.Date t = new java.util.Date();
		
		java.util.Calendar c = java.util.Calendar.getInstance();
		java.util.Calendar c2 = java.util.Calendar.getInstance();
		
		String monthnamerus = "";
		String weeknamerus = "";
		String minutesFormat = "";
		int dayOfYear = 0;
		int dayOfMonth = 0;
		
		if(c.get(java.util.Calendar.MONTH) == 0){
		 monthnamerus = " янв. ";
		 dayOfYear = 0;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 1){
		 monthnamerus = " фев. ";
		 dayOfYear = 31;
		 dayOfMonth = 28;
		};
		if(c.get(java.util.Calendar.MONTH) == 2){
		 monthnamerus = " мар. ";
		 dayOfYear = 59;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 3){
		 monthnamerus = " апр. ";
		 dayOfYear = 90;
		 dayOfMonth = 30;
		};
		if(c.get(java.util.Calendar.MONTH) == 4){
		 monthnamerus = " мая ";
		 dayOfYear = 120;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 5){
		 monthnamerus = " июня ";
		 dayOfYear = 151;
		 dayOfMonth = 30;
		};
		if(c.get(java.util.Calendar.MONTH) == 6){
		 monthnamerus = " июля ";
		 dayOfYear = 181;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 7){
		 monthnamerus = " авг. ";
		 dayOfYear = 212;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 8){
		 monthnamerus = " сен. ";
		 dayOfYear = 243;
		 dayOfMonth = 30;
		};
		if(c.get(java.util.Calendar.MONTH) == 9){
		 monthnamerus = " окт. ";
		 dayOfYear = 273;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 10){
		 monthnamerus = " ноя. ";
		 dayOfYear = 304;
		 dayOfMonth = 31;
		};
		if(c.get(java.util.Calendar.MONTH) == 11){
		 monthnamerus = " дек. ";
		 dayOfYear = 334;
		 dayOfMonth = 31;
		};
		
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 1){
		 weeknamerus = "Вск.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 2){
		 weeknamerus = "Пнд.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 3){
		 weeknamerus = "Втр.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 4){
		 weeknamerus = "Срд.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 5){
		 weeknamerus = "Чтв.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 6){
		 weeknamerus = "Птн.";
		};
		if(c.get(java.util.Calendar.DAY_OF_WEEK) == 7){
		 weeknamerus = "Сбт.";
		};
		
		if(c.get(java.util.Calendar.MINUTE) < 10){
			minutesFormat = "0" + c.get(java.util.Calendar.MINUTE);
		}
		if(c.get(java.util.Calendar.MINUTE) >= 10){
			minutesFormat = "" + c.get(java.util.Calendar.MINUTE);
		}		
		
		
		g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL));
        g.drawString("Год | " + (((dayOfYear + c.get(java.util.Calendar.DAY_OF_MONTH)) * 100) / 365) + "% | " + (dayOfYear + c.get(java.util.Calendar.DAY_OF_MONTH)) + " дн.", w/18, h/18, Graphics.LEFT|Graphics.TOP);
		g.drawString("Месяц | " + ((c.get(java.util.Calendar.DAY_OF_MONTH) * 100) / dayOfMonth) + "% | " + c.get(java.util.Calendar.DAY_OF_MONTH) + " дн.", w/18, h/18+16, Graphics.LEFT|Graphics.TOP);
		g.drawString("Неделя | " + ((c.get(java.util.Calendar.DAY_OF_WEEK) * 100) / 7) + "% | " + weeknamerus, w/18, h/18+32, Graphics.LEFT|Graphics.TOP);
		g.drawString("День | " + ((c.get(java.util.Calendar.HOUR_OF_DAY) * 100) / 24) + "% | " + c.get(java.util.Calendar.HOUR_OF_DAY) + ":" + minutesFormat, w/18, h/18+48, Graphics.LEFT|Graphics.TOP);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
	    g.drawString(weeknamerus + ", " + (c.get(java.util.Calendar.DAY_OF_MONTH)) + monthnamerus + c.get(java.util.Calendar.YEAR) + " г.", w-2, h-5, Graphics.RIGHT|Graphics.BOTTOM);
	 

    } 
	
}