   M S B A M L   `   `   `  ����O  KProjektImplementacja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ProjektImplementacjaProjektImplementacja  5           ProjektImplementacja.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:ProjektImplementacja     5        N� Title$  Panel logowania��5	       N� 
Background
 ����  � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType	 �� 
TargetType
 ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFFFC7BB��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFEE9581��6<   �� 5   
   $ 	#FFF58E78��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      "	 ��6&   .R�5)      �� $
 border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5*      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted$
 true��6=   . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver$
 true��6=   . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � ��$
 true��6;   . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {�$ false��6;   . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5D      � -   5         � LayoutTransform 5E   
   �� 5F      -   5        ScaleTransform��5F       � ColumnDefinitions 5I   
   �� 5J      $��* �6   �� 5K      $��7* �6   �� 5L      $��* �6   �� 5M      $��7* �6   �� 5N      $��* �6    � RowDefinitions 5Q   
   �� 5R      $��* �6   �� 5S      $	��15* �6   �� 5T      $��* �6   .+�5W   
   � $��1��6   $��1��6    5X      �� 5Y      $��* �6    �� 5Z      $��* �6    �� 5[      $��* �6    �� 5\      $��* �6    .+�5_      �� $��4��6   
������� J� Opacity$	 0.8Q�66   �� 5a      $��0��6   $��Zaloguj��6%   $��50(�64   $��Center=�6B   ���	#FFF58E78$��Center=�6v    J� Effect 5b      3  -System.Windows.Media.Effects.DropShadowEffect  5c         ShadowDepth$ 2Q�6'      	Direction$	 330Q�67      Color$ Black��6G      Opacity$	 0.5Q�6U      
BlurRadius$ 4Q�6c   5e      �� 5g      $��1��6   $��Center=�6&   $
��20,0q�6A   .+�5h      �� $��Nazwa użytkownika��6   ���	#FFF58E78$��20(�6K    5i        5j      $ 1Q�6+   $	 330Q�6;   $ Black��6K   $	 0.5Q�6Y   $ 3Q�6g   5l      �� 5m      -   5         ��Name$ UsernameTextBox��5m      $��20(�63   $��30��6A   6O   5n      �� 5p      $��2��6   $��Center=�6&   $
��20,0q�6A   .+�5q      �� $��2��6   $��Hasło��6&   ���	#FFF58E78$��20(�6M    5r        5s      $ 1Q�6+   $	 330Q�6;   $ Black��6K   $	 0.5Q�6Y   $ 3Q�6g   5u      G� 5v      -   5         G�Name$ PasswordTextBox��5v      $��2��67   $��20(�6D   $��30��6R   6`   5w      �� 5y      $��3��6   $��Center=�6&   .+�5z      �� -   5         ��Name$ 	ErrorText��5z      $��3��6/   $��Miejsce na błąd.��6<   
���  ��$��Center=�6e   $��15(�6�   $y�Hidden=�6�   6�   �� 5{      -   5        #��� 
 5{      $��4��6@   $��50,10q�6M   $��5q�6\   $��20(�6h   
����������	#FFF58E78$��0q�6�   .��6�   	Zaloguj5}      5~      5      � 5�   
   $��3��6   $��1��6    5�      �� 5�      $��2* �6    �� 5�      $��4* �6    �� 5�      $��2* �6    �� 5�      $��3* �6    �� 5�      $��* �6    .+�5�      �� $��1��6   
�������$	 0.8Q�62   �� 5�      $��1��6   $��Center=�6&   .+�5�      �� $��Center=�6   ���	#FFF58E78$��30(�6P   Nie masz konta? 5�        5�      $ 1Q�6+   $	 330Q�6;   $ Black��6K   $	 0.5Q�6Y   $ 3Q�6g   5�      �� 5�      $��Center=�6   $��25(�69   ���	#FFF58E78-+To żaden problem! Załóż konto za darmo. 5�        5�      $ 1Q�6+   $	 330Q�6;   $ Black��6K   $	 0.5Q�6Y   $ 3Q�6g   5�      �� 5�      #��� 
 6   $��3��6@   $��5q�6M   $��
50,30,50,0q�6Y   $��25(�6m   
����������	#FFF58E78$��0q�6�   .��6�   Załóż konto5�      5�      �� 5�      #��� 
 6   $��3��6<   $��20q�6I   $��25(�6U   
����������	#FFF58E78$��0q�6�   .��6�   Przeglądaj eventy5�      5�      5�      5�      