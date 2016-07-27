# ProjetoFinalGrafos

Simulação do algoritmo de Dijkstra para resoluções de caminhos de rotas para personagens com IA em jogos.
Com utilização de interface gráfica por meio do Unity 5.
Para rodar o projeto:

1) Clique no botão para escolher o vértice inicial e clique em um vértice, ele mudará de cor.
2) Clique no botão para escolher o vértice final e clique em um vértice, ele mudará de cor.
3) Gere os possíveis caminhos clicando em um vértice e depois clicando em outro, 
aparecerá um campo para inserir o peso do caminho, e uma seta indicará que aquele caminho existe.
4) Insira monstros e moedas com o uso dos botões na interface. 

Sobre a simulação:
O personagem evitará monstros quando estiver com menos de 30% da vida, se esta condição estiver satisfeita, a cada passo
dado o personagem aumentará o peso de caminhos que levam para monstros em 5 pontos.
O personagem também dará prioridades para moedas, aumentando o peso de todos os caminhos vizinhos que não possuem moedas em 5 pontos.

Ao clicar em "Executar", será mostrado com o uso de cores quais por quais vértices e por quais arestas o personagem passou,
no console são imprimidos os testes que foram realizados, e ao final do processo é indicado o caminho que o personagem deve seguir para
realizar o menor caminho entre os pontos inicial e final de forma que ele evite monstros quando estiver com vida baixa, 
e pegando o máximo de moedas que puder.
