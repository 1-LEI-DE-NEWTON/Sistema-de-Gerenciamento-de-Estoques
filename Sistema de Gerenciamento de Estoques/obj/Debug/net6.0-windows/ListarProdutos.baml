   M S B A M L   `   `   `  ????_  [Sistema de Gerenciamento de Estoques, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:GerenciadorDeEstoquesGerenciadorDeEstoques  5      )    #GerenciadorDeEstoque.ListarProdutos   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5local#clr-namespace:GerenciadorDeEstoques     5        ? Title$  ListarProdutos??5      $	??450??6   $	??800??6+   .??5
      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6    ?? Orientation$ 
Horizontal=?6"   $??10q?6;   .+?5      ?? $??Filtrar por:??6   $??Center=?6+   $??18(?6F   ?? 5      -   5         ??Name$ 	cbxFiltro??5      $??10,0,0,0q?6*   $??Center=?6<   $??18(?6W   .@?5      ?? $
??Nome??6   ?? 5      $??
Quantidade??6   ?? 5      $??Preço??6   5      ?? 5      -   5         ??Name$ 	txtFiltro??5      $??10,0,0,0q?6)   $??Center=?6;   $??18(?6V      Estilo_Placeholder#??[  5      
 ? Tag$- 'Digite aqui o nome para filtrar a lista??6B   $y?	Collapsed=?5      ?? 5      -   5        $ 	txtMinimo??5      $??10,0,0,0q?6)   $??Center=?6;   $??18(?6V   #??[  5      $  ??6E   $y?	Collapsed=?5      ?? 5      -   5        $ 	txtMaximo??5      $??10,0,0,0q?6)   $??Center=?6;   $??18(?6V   #??[  5       $  ??6E   $y?	Collapsed=?5!      ?? 5$      -   5        $??Filtrar??5$      $??10,0,0,0q?6'   $??Center=?69   ???#007acc
???????$??18(?5%   =   6K   5(      ?? 5*   
   -   5         ??Name$ lvwProdutos??5*       $??1??6   $??10q?65   $??18(?6A    ?? View 5+      ?? 5,      .P?5-      ?? $
??Nome??6%    ?? Width$	 200??63   	 ?? DisplayMemberBinding	 6?   ?? *Nome+?? 5.      $??
Quantidade??6%   $	 150??69   	 6E   ?? *
Quantidade+?? 5/      $??Preço??6%   $	 150??64   	 6@   ?? *Preco+?? 50      $??Opções??6%   $
 Auto??65   
 ?? CellTemplate
 51      ?? 52      .R?53   "   ?? $ 
Horizontal=?6-   .+?54   &   ?? -   5        $??Editar??54   -   $??5q?6>   ???#007acc
???????$??14(?55   @   6N   ?? 56   &   -   5        $??Excluir??56   -   $??5q?6?   ???#007acc
???????$??14(?57   @   6N   58   #   59      5;      5<      5>      5?      5@      