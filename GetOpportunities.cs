using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace api_auction
{

    
    /// <summary>
    /// Objeto de retorno da lista de oportunidades
    /// </summary>
   /// <value>Total <c>Total</c> represents the point's x-coordinate.</value>
    public partial class GetOpportunities
    {
        
        
        /// <summary>Total de oportunidades encontradas</summary>
        [JsonPropertyName("total")]
        public long Total { get; set; }

        /// <summary>Lista de oportunidades</summary>
        [JsonPropertyName("auctions")]
        public Auction[] Auctions { get; set; }
    }

    /// <summary>Objeto da oportunidade</summary>
    public partial class Auction
    {
        
        /// <summary>Status em que se encontra a oportunidade</summary>
        [JsonPropertyName("status_auction")]
        public string AuctionStatusFlow { get; set; }

        /// <summary>Se True, liberar o botão análise de oportunidade</summary>
        [JsonPropertyName("has_answers")]
        public bool HasAnswers { get; set; }

        /// <summary>Se True, liberar botão de baixar anexo</summary>
        [JsonPropertyName("has_attachment")]
        public bool HasAttachment { get; set; }

        /// <summary>Cliente</summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }

        /// <summary>Tipo do pregão. Ex: SRP</summary>
        [JsonPropertyName("auction_type")]
        public string AuctionType { get; set; }

        /// <summary>Modo do pregão</summary>
        [JsonPropertyName("auction_mode")]
        public string AuctionMode { get; set; }

        /// <summary>Número da oportunidade</summary>
        [JsonPropertyName("auction_number")]
        public string AuctionNumber { get; set; }

        /// <summary>Descrição da oportunidade</summary>
        [JsonPropertyName("auction_description")]
        public string AuctionDescription { get; set; }

        /// <summary>Portal do governo</summary>
        [JsonPropertyName("portal")]
        public string Portal { get; set; }

        /// <summary>Número da unidade compradora</summary>
        [JsonPropertyName("buyer_unit")]
        public string BuyerUnit { get; set; }

        /// <summary>Data da publicação</summary>
        [JsonPropertyName("publish_date")]
        public DateTimeOffset PublishDate { get; set; }

        /// <summary>Data da abertura</summary>
        [JsonPropertyName("auction_date")]
        public DateTimeOffset AuctionDate { get; set; }

        /// <summary>Data limite de acolhimento</summary>
        [JsonPropertyName("target_proposal")]
        public DateTimeOffset? TargetProposal { get; set; }

        /// <summary>Data limite para análise de operação</summary>
        [JsonPropertyName("target_operational")]
        public DateTimeOffset? TargetOperational { get; set; }

        /// <summary>Data limite para análise do cliente</summary>
        [JsonPropertyName("target_client")]
        public DateTimeOffset? TargetClient { get; set; }

        /// <summary>Número alternativo do pregão. </summary>
        [JsonPropertyName("alternative_auction_number")]
        public string AlternativeAuctionNumber { get; set; }
    }

    public partial class AuctionMode
    {
        [JsonPropertyName("auction_mode")]
        public string Mode { get; set; }

        [JsonPropertyName("auction_type")]
        public string Type { get; set; }

        [JsonPropertyName("auction_date")]
        public DateTimeOffset Date { get; set; }
    }

    /// <summary>Objeto de detalhes do itens da oportunidade</summary>
    public partial class FinalItem
    {
        /// <summary>Quantidade</summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>Tipo da unidade. </summary>
        [JsonPropertyName("item_unit_type")]
        public string ItemUnitType { get; set; }

        /// <summary>Se o item foi rejeitado</summary>
        [JsonPropertyName("item_reject")]
        public bool ItemReject { get; set; }

        /// <summary>Número do item</summary>
        [JsonPropertyName("item_number")]
        public string ItemNumber { get; set; }

        /// <summary>Número do grupo. Ex: G1,G2. Quando ng é para itens que não fazem parte de um grupo. </summary>
        [JsonPropertyName("group_number")]
        public string GroupNumber { get; set; }

        /// <summary>Descrição do item</summary>
        [JsonPropertyName("auction_item_description")]
        public string AuctionItemDescription { get; set; }

        /// <summary>Detalhes do item</summary>
        [JsonPropertyName("auction_item_details")]
        public string AuctionItemDetails { get; set; }

        /// <summary>Valor estimado do item.</summary>
        [JsonPropertyName("estimated_value")]
        public decimal? EstimatedValue { get; set; }

        /// <summary>Se o item é um serviço</summary>
        [JsonPropertyName("is_service")]
        public bool IsService {get; set;}
    }
    
}