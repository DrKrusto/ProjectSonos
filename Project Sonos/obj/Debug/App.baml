   M S B A M L   `   `   `  ����H  DProject Sonos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Project_SonosProject_Sonos  5          Project_Sonos.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -localclr-namespace:Project_Sonos     5        �� 	Resources  5         soundButton �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   Opacity	   	Direction
   ShadowDepth   RenderingBias   
BlurRadius  contextMenuTemplate �� 
TargetType ��Name �� CornerRadius �� Padding �� Color K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers �� 
TargetName  leftMenuButton  listContainerStyle  topBarButtons  topBarButtonsQuit  WindowColor  ContentAreaColorLight  ContentAreaColorDark 	 DisabledControlLightColor 
 DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor  ControlLightColor  ControlMediumColor  ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor   NavButtonFrameColor ! MenuPopupBrush �� EndPoint �� 
StartPoint � Color � Offset $"  ProgressBarIndicatorAnimatedFill��%�  &	        &	     &	 �    &	 �    &	 �    &	 �    &	     &	 )    &	 J    &		 k    &	
 �    &	 �    &	 �    &	 �    &	 	    &	 -	    &	 N	    &	 o	    &	 �	    &	 �	    &	 �	    &	 
    &	 6
    &	 W
    &	 x
    &	 �
    &	 �
    &	 �
    &	 �
    &	     &	 :    &	 W    &	  x    &	! �    &	" `    �� 5   
   " A�6$    5	      P� 5
       �@J�IsMouseOver . . �5      ��  �@J�Effect 5        5      $ Black��6/   $ 1Q�6=   $	 0Q�6I   $
 0Q�6W   $ Performance=�6g   $ 15Q�6�   5      5      5      �� 5   
   " ��6,   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       �@�IsSharedSizeScope . 67   �� 5       �@��HasDropShadow . 6.   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Border��6!   ���	#FF18191C$��1q�6H   $ 4��6\   $	 5pxq�6m   ��5      �� 5   "   $ 	#FF18191C��62   ._�5       ��  . $ Cycle=�6<   5!       5"      P� 5#       �@��HasDropShadow . . �5$   "   �� $ Border��6)    �@��Padding$ 0,3,0,3q�6P   �� 5%   "   $ Border��6)    �@��CornerRadius$ 4��6U   5&      5(      5*      5+      �� 5-   
   " A�6'   .�5/      ��  �@J�Opacity$ 1Q�60    50      P� 51       �@J�IsMouseOver . . �53      ��  �@J�Opacity$
 0.75Q�68   54      56      �� 58   
   " ��6+   .�59      ��  � ��$ 1q�60   �� 5:       � �� 5;      �� 5<      " ��6&   .R�5=      �� $ Border��6!   #��z��61   #��z��6[   #��z��6�   ._�5>      �� $��Content��6/   5?      5@      5B       5C      P� 5D       �@��
IsSelected . . �5E      ��  � ��
 ���� 63   5F      5H      �� 5J   
   " ��6&   .�5K      ��  � �� �	#FFB9BBBE61   �� 5L       � ��
 ���� 61    5M      P� 5N       �@J�IsMouseOver . . �5O      ��  � ��
 �����69   �� 5P       � ��
 �����69   5Q      5S      �� 5U   
   " ��6*   .�5V      ��  � �� �	#FFB9BBBE61   �� 5W       � ��
 ���� 61    5X      P� 5Y       �@J�IsMouseOver . . �5Z      ��  � ��
 �����69   �� 5[       � �� �	#FFE8112369   5\      5^      ��5a   
   	#FFE8EDF9��6/   ��5b   
   	#FFC5CBF9��69   ��5c   
   	#FF7381F9��68   ��5e   
   	#FFE8EDF9��6=   ��5f   
   	#FFC5CBF9��6<   ��5g   
   	#FF888888��6;   ��5i   
   	#FFC5CBF9��6;   ��5j   
   	#FFDDDDDD��6:   ��5l   
   	White��61   ��5m   
   	#FF7381F9��66   ��5n   
   	#FF211AA9��64   ��5p   
   	#FF3843C4��69   ��5q   
   	#FF211AA9��67   ��5t   
   	#FF444444��6.   ��5u   
   /+sc#1, 0.004391443, 0.002428215, 0.242281124��6T   ��5x   
   	#FFCCCCCC��64   ��5y   
   	#FF888888��65   ��5z   
   	#FF444444��63   ��5|   
   	#FF888888��6;   ��5}   
   	#FF444444��6:   ��5   
   	#FFAAAAAA��6<   ��5�   
   	#FF888888��6;   ��5�   
   	Black��6;   ��5�   
   	#FFC5CBF9��62   ��5�   
   	Black��6>   ��5�   
   	#FFC5CBF9��68   ��5�   
   	#FF3843C4��67   �� 5�   
   $ 0.5,1&�5�      $ 0.5,0&�5�      .��5�      � # �  6   $ 0Q�5�      � 5�      # �  6   $	 0.5Q�5�      � 5�      # �  6   $ 1Q�5�      5�      �� 5�   
   $	 0,0&�5�      $	 1,0&�5�      ��5�      � � 5�      $ 	#000000FF��6#   $ 0Q�5�      � 5�      $ 	#600000FF��6#   $	 0.4Q�5�      � 5�      $ 	#600000FF��6#   $	 0.6Q�5�      � 5�      $ 	#000000FF��6#   $ 1Q�5�      5�      5�      5�      5�      