   M S B A M L   `   `   `  ����B  >Lesson1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Lesson1.ValidationRulesLesson1.ValidationRules  5      +clr-namespace:Lesson1.ViewLesson1.View  5      '    !Lesson1.View.RecipientsInfoEditor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4vr%clr-namespace:Lesson1.ValidationRules     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      &localclr-namespace:Lesson1.View  5      $��438.559��5	      $��275.636��60     � DataContext  5
      �� *MainWindowModel+   Locator �� Source# [  .��5      �  � 	Resources 5   
    �� 
TargetType �� Property �� Value"  FontAwesome.WPF.ImageAwesome   
Foreground   Icon � ToolTip	 �� ElementName
 �� Triggers P� Property P� Value��%{  '��       �� 5      " ��6   .�5      ��  � ��$ 2,5,15,3q�6+   6>   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� .+�5   "     $��16��62   $��Right=�6>   $��14��5   2   
 �  ��$ Warning=�6N    5   2   �� *42AdornedElement.(Validation.Errors)[0].ErrorContent+$	 AdornedElement���� 5   "   
���  ��$��4q�6;   $��1q�6O   ._�5   &   �� $��AdornedElement��6@   5   #   5      5      5      
 5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 �����68   �� 5        � ��
 �����67   5!      5#      5$       � ColumnDefinitions 5%   
   �� 5&      $
��Auto �6   �� 5'       � RowDefinitions 5)   
   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   �� 5,      $
��Auto �6   �� 5-      .+�5/   
   �� $��0��6   $��0��6$   $��Id��61   �� 50   
   $��0��6   $��1��6$   $��Имя��61   �� 51   
   $��0��6   $��2��6$   $��Email��61   �� 53   
   $��1��6   $��0��6"    �� 
IsReadOnly .  ��6/   �� *SelectedRecepient.Id+ �� NotifyOnValidationError . 6s   �� 54   
   $��1��6   $��1��6"   ��6/   �� *SelectedRecepient.Name+ .  �� ValidatesOnDataErrors .  �� ValidatesOnExceptions . �� 55   
   $��1��6   $��2��6"   .��60   ��56      �� 57       �� Path$ SelectedRecepient.Email�6    .  �� ValidationRules 58      ;  5System.Windows.Controls.NotifyDataErrorValidationRule  59      5  /System.Windows.Controls.ExceptionValidationRule  5:      1  +Lesson1.ValidationRules.regExValidationRule  5;         Pattern$ \w+@\w+\.\w+��61      ErrorMessage$R LНеверный формат адреса электронной почты��6H   5=      .��5>      5?      A� 5A   
   $��0��6   $��3��6&   $��2��63   $	��Top=�6G   $��Center=�6_   .+�5B      �� $��0,10,0,0q�6   $��20, 5q�5C      $+��%Сохранить изменения��5F      ��5D      �� *WriteRecipientDataCommand+��5E      �� *SelectedRecepient+5F      �� 5G      $��0,10,0,0q�6   $��20, 5q�5H      $��Создать��5K      ��5I      �� *WriteRecipientDataCommand+��5J      �� *SelectedRecepient+5K      5L      5M      5N      