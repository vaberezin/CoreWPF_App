   M S B A M L   `   `   `  ����E  ACoreWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CoreWpfApp
CoreWpfApp  5   	       CoreWpfApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CoreWpfApp     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullZ VMaterialDesignThemes.MahApps, Version=0.1.4.1513, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	   -   5        $��	PlitkaApp��5   	     � Title$  Группа ВК��5   	   $	��450��6   $	��800��6(      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��12(�5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      -   5         ��Name$ LastRow��5      $��* �6-   .+�5!   
   �� -   5         ��Name$ YandexMusicBtn��5!      $��0��6)   $��0��69   $��4��6F   $#��Яндекс.Музыка API��6Z   $��24(�6v   $��	0,38,0,39q�6�   6�   �� 5"   
   -   5        $ YandexWeatherBtn��5"      $��4��6+   $��0��6;   $#��Яндекс.Погода API��6H   $��24(�6d   $��	0,38,0,39q�6r   �� 5#   
   -   5        $ RainFlowCalcBtn��5#      $��0��6*   $��1��6:   $#��Расчет ливневки��6H   $��18(�6c   $��	0,38,0,38q�6�   6�   �� 5$   
   -   5        $ RegulationsBtn��5$      $��1��6)   $��1��69   $��СНиП, СП��6F   $��18(�6Y   $��	0,38,0,38q�6g   6z   �� 5%   
   -   5        $ FireFightBtn��5%      $��2��6'   $��1��67   $ ��Пожаротушение��6D   $��18(�6\   $��2��6j   $��	0,38,0,38q�6~   �� 5&   
   -   5        $ 
InnerVkBtn��5&      $��0��6%   $��2��65   $
��ВК��6B   $��18(�6O   $��	0,38,0,39q�6]   �� 5'   
   -	   5        $ WellsBtn��5'      $��0��6#   $��2��63   $#��Подбор колодцев��6@   $��18(�6Z   $��	0,38,0,39q�6h   �� 5(   
   -
   5        $ 
TaskMgrBtn��5(      $��0��6%   $��3��65   $��4��6B   $5��/Менеджер задач с историей��6V   $��24(�6z   $��	0,38,0,38q�6�   �� 5)   
   -   5        $ YandexMapsBtn��5)      $��1��6(   $��2��68   $��3��6E   $B��<Быстрый маршрут по Яндекс.Картам��6Y   $��18(�6�   $��	0,38,0,39q�6�   �� 5*   
   -   5        $ TimerBtn��5*      $��4��6#   $��3��63   $	��100��6t   $%��Запустить таймер��6�   $��24(�6�    J� Opacity$	 0.8Q�6�   
�����_�$��0,4,0,4q�6�   ��6@   ��  �� ElementName$ LastRow�� �� Path$ Height�6�   �� 5,   
   -   5         ��Name$ WorkingText��5,      $��4��6)   $��1��69   $��Center=�6F   $2��,Работаем в своем темпе :)��6a   $��18(�6�   	 �� TextAlignment$	 Center=�6�   $��5,0,5,0q�6�   6�   �� 5-   
   -   5        $ WorkingTimeTxtBlock��5-      $��4��61   $��2��6A   $��Center=�6N   $��Вперед!��6i   $��18(�6x   $	 Center=�6�   $��5,0,5,0q�6�   5/      50      