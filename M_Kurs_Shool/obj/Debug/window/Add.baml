   M S B A M L   `   `   `  ����G  CM_Kurs_Shool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:M_Kurs_Shool.windowM_Kurs_Shool.window  5   	       M_Kurs_Shool.window.Add   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:M_Kurs_Shool.window     5   	     � Title$	  Add��5   	   $	��450��6   $	��800��6"   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6    .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6%   y�6>   �� *
NewProduct+.+�5      �� $/��)Идентификатор услуги: ��6   �� 5      ��6   �� *CurrentAdd.Id+5      �� 5   
   $
��5 60q�6   $��1��6#   .+�5      �� $
��left=�5      ��5      �� *
ClientList+ �� SelectedItem 5      �� *CurrentAdd.Client+��5      �� 5      .R�5      �� ��6    �� *
FullName+5      5      �� 5!      $��Тип данных��6   �� 5"      ��6   �� *CurrentAdd.ContactTypeId+�� 5#      $#��Сумма контракта��6   �� 5$      ��6   �� *CurrentAdd.Summa+�� 5&      -   5        $	��100��5&      $��5q�6!   $
��Left=�6,   .��6`   Сохранить6k   5'      5(      5)      