   M S B A M L   `   `   `  ����M  IHouseBuilderWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HouseBuilderWindowHouseBuilderWindow  5   	        HouseBuilderWindow.Window1   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HouseBuilderWindow     5   	     � Title$  Window1��5   	   $	��402��6   $	��522��6&   .��5	      � $	��NaN��6   $��0,0,0,-6q�6   .+�5
   
   �� $	��NaN��6   $��	0,0,0,135q�6"   .+�5      �� $1��+Введите площади этажей:��6   $��16(�66   $��Center=�6D   $��41��6a   $	��263��6m   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ label1��5      $"��Площадь этажа 1:��6(   �� 5      -   5         ��Name$ TextBox_FirstFloorArea��5      $	��100��6:   $��30��6F   $
��Left=�6R   5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $ label2��5      $"��Площадь этажа 2:��6(   �� 5      -   5        $ TextBox_SecondFloorArea��5      $	��100��6;   $��30��6G   $
��Left=�6S   5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $ label3��5      $"��Площадь этажа 3:��6(   �� 5      -   5        $ TextBox_ThirdFloorArea��5      $	��100��6:   $��30��6F   $
��Left=�6R   �� 5      $E��?Количество необходимых доп. опций:��6   �� 5      -   5        $ TextBox_NumberOfOptions��5      $��61��6;   5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $ label4��5      $"��Площадь этажа 4:��6(   �� 5      -	   5        $ TextBox_FourthFloorArea��5      $	��100��6;   $��30��6G   $
��Left=�6S   5      �� 5      $ 
Horizontal=�6   .+�5      �� -
   5        $ label5��5      $"��Площадь этажа 5:��6(   �� 5       -   5        $ TextBox_FifthFloorArea��5       $	��100��6:   $��30��6F   $
��Left=�6R   5!      5"      �� 5#   
   -   5         ��Name$ Button_Calculate��5#      $��30(�6+   $��Рассчитать��69   $
��Left=�6N   $��177,218,0,0q�6i   $	��Top=�6~    J� RenderTransformOrigin$ 
0.503,0.67&�6�   6�   5$      5%      