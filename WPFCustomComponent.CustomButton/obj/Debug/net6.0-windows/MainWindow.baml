   M S B A M L   `   `   `  ????#  WPFCustomComponent.CustomButton0    *WPFCustomComponent.CustomButton.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5      ?  ? RowDefinitions 5	   
   ?? 5
      ?? 5      .+?5   
   ?? $??30q?6   $	??100??6   $	??200??6*   $??Hello??66   ??5      ?? 5       ?? 
TargetType" ??6"   .R?5      ??  ??Name$ PART_border??66   
???2͚?$??0q?6K   $??5q?6V   
???   ? ?? CornerRadius$ 15??5   1   ._?5      ?? #??z??6+   #??z??5   +   #??z??5   +   
???   ?#??z??5   +   5      5       ?? Triggers 5      ]? 5       ]? 
Conditions 5      ?? 5   "    ?? Property ? ?? ?? Value$
 true??6A   6P   ?? 5   "    ?@J?IsMouseOver$
 true??6C   6R   	 N? EnterActions	 5       ?? 5!   "   .??5"   &   ?? .??5#   *   t? 
 ?? 
TargetName$
 PART_border??6=    ?? TargetProperty$ Margin?5$   =    g? AutoReverse$
 True??6`    t? From 05%   =   	 t? To 56F    g? Duration$ 0:0:0.2D?6M   5&   +   5'   '   5(   #   5*      5,      5.      d? 5/   
   $??1??6   $	??100??6$   $	??200??61   ??50      ?? 51      " d?6"   .R?52      ?? 
??? ? ????#ffd789$??1q?6F   $ 50??6Z   ._?53      ?  ? ColumnDefinitions 54      ?? 55   !   ?? 56   !   .+?58      A?  A?Name$ 
InnerShape??6L   $??60??6&   $??60??62   ???#c9cac959      5:      5;       5<      P? 5=       P? Property ?@d?	IsChecked P? Value$
 TrueY?67   . ?5>      ??  ?? 
TargetName$ 
InnerShape??6%    ?? Property ? ?? ?? Value$ 1??6T   6`   5?      P? 5@       ?@d?	IsChecked$ FalseY?67   . ?5A      ?? $ 
InnerShape??6%    ? ??$ 0??6T   6`   5B      5D      5F      5G      5H      