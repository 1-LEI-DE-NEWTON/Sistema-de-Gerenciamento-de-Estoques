   M S B A M L   `   `   `  ????_  [Sistema de Gerenciamento de Estoques, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Sistema_de_Gerenciamento_de_Estoques$Sistema_de_Gerenciamento_de_Estoques  5   	   9    3Sistema_de_Gerenciamento_de_Estoques.EditorProdutos   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:Sistema_de_Gerenciamento_de_Estoques     5   	     ? Title$  Editar Produto??5   	   $	??303??6    $	??411??6-   .??5	      ? $??0,0,0,82q?6    ? RowDefinitions 5
   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? $??Nome:??6   $??0??6    $??43,10,10,10q?6-   ?? 5   
   -   5         ??Name$ txtNome??5      $??0??6#   $??87,10,10,10q?60      Estilo_Placeholder#??[  5      
 ? Tag$ Digite o nome do produto??6=   ?? 5   
   $??Quantidade:??6   $??1??6&   $??10,10,10,10q?63   ?? 5   
   -   5        $ txtQuantidade??5      $??1??6)   $??87,10,10,10q?66   #??[  5      $$ Digite a quantidade do produto??6>   ?? 5   
   $??Preço:??6   $??2??6!   $??43,10,10,10q?6.   ?? 5   
   -   5        $ txtPreco??5      $??2??6$   $??87,10,10,10q?61   #??[  5      $  Digite o preço do produto??6=   ?? 5   
   -   5        $??Salvar??5      $??3??6"   $??222,10,44,-15q?6/   $??2??6[   ???#007ACC???#FFFFFF$
??Bold"?5       $??20(?6#   $??	15,5,15,5q?61    ? 	Resources 5!       ?? 
TargetType ?? Property ?? Value ?? Triggers	 ?? Binding
 ?? ElementName ?? Value??%?  '??       '?? Z     ?? 5"      " ??6   .?5#      ??  ?@??CornerRadius$ 10??65   6B   5$      ?? 5&      " ??6    5'      ?? 5(      	 6&   ?? *Text+$
 txtNome??  6T   .a?5)      ??  ? {?$ False??6:   5*      ?? 5,      	 6&   ?? *Text+$
 txtQuantidade??  6Z   .a?5-      ??  ? {?$ False??6:   5.      ?? 50      	 6&   ?? *Text+$
 txtPreco??  6U   .a?51      ??  ? {?$ False??6:   52      54      55      57      ?? 59   
   -   5        $??Cancelar??59      $??3??6$   $??24,10,254,-15q?61   ???#007ACC???#FFFFFF$
??Bold"?5;      $??20(?6#   $??	15,5,15,5q?61   $??2??6E    5<      ??%d   '??       ?? 5=      " ??6   .?5>      ??  ?@??CornerRadius$ 10??65   6B   5?      5@      5A      5B      5C      