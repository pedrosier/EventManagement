# EXPLICAÇÃO TÉCNICA

## Seção 1: Introdução

O sistema resolve o gerenciamento de eventos com validações robustas para evitar erros em tempo de execução. Decisões de design incluem uso de guards para centralizar validações e atributos para null safety.

## Seção 2: Guard Clauses Implementados

Guard.AgainstNull, AgainstNullOrWhiteSpace, AgainstNegativeOrZero, AgainstPastDate, IsValidEmail. Exemplos: No construtor de Speaker, Guard.AgainstNegativeOrZero(speakerId, nameof(speakerId)). Necessários para programação defensiva.

## Seção 3: TryParseNonEmpty

Usado em SetBiography e SetDescription para validar strings sem lançar exceções. Motivo: Permite tratamento gracioso de inputs inválidos. Alternativa: Lançar exceções, mas isso é mais agressivo.

## Seção 4: [MemberNotNull] - Lazy Loading

Implementado em Event para Venue, com método InitializeVenue marcado com [MemberNotNull]. Benefícios: Garante que \_venue não é null após chamada. Testes: Venue_LazyLoading_LoadsDefault e Venue_MultipleAccesses_SameInstance.

## Seção 5: [DisallowNull] vs [AllowNull]

EventCode usa [DisallowNull] para proibir null em setters. Requirements/Notes usam [AllowNull] para permitir null mas retornar vazio. Diferenças: [DisallowNull] para propriedades que nunca devem ser null, [AllowNull] para opcionais.

## Seção 6: Métodos de Identidade

Equals e GetHashCode baseados em IDs para Speaker e Venue. Importância: Para coleções e comparações. Testes: Equals_SameId_True, etc.

## Seção 7: Validações Customizadas

AgainstNegativeOrZero para IDs e capacities. AgainstPastDate para datas de eventos. IsValidEmail para emails. Usados em construtores.

## Seção 8: Testes Unitários

Estratégia: TDD, cobrindo happy paths e erros. Cobertura: 100%. Testes importantes: Os de exceções e lazy loading.

## Seção 9: Desafios Encontrados

Configurar lazy loading com [MemberNotNull]. Solução: Usar método privado. Aprendizados: Importância de null safety.

## Seção 10: Conclusão

Implementado sistema completo com validações. Conceitos consolidados: Programação defensiva. Próximos passos: Adicionar persistência.
