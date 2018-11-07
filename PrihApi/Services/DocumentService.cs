using Lime.Messaging.Contents;
using Lime.Protocol;
using Microsoft.Extensions.Configuration;
using PrihApi.Interfaces;
using PrihApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrihApi.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IConfiguration _configuration;

        public DocumentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DocumentCollection CreateBarCarrossel(List<BarData> barsData, double myLat, double myLong)
        {
            var bars = new DocumentCollection
            {
                ItemType = DocumentSelect.MediaType,
            };

            var selectBars = new List<DocumentSelect>();
            foreach (var bar in barsData)
            {
                selectBars.Add(new DocumentSelect
                {
                    Header = new DocumentContainer
                    {
                        Value = new MediaLink
                        {
                            Text = bar.Address,
                            Title = bar.Name,
                            Uri = new Uri(string.Format(_configuration["gmapsconfig:staticmapuri"], bar.Lat, bar.Long))
                        }
                    },
                    Options = new DocumentSelectOption[3]
                    {
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = new WebLink
                                {
                                    Title = "Como Chegar",
                                    Uri = new Uri(string.Format(_configuration["gmapsconfig:mapsdir"],bar.Lat,bar.Long,myLat,myLong))
                                }
                            }
                        },
                        new DocumentSelectOption
                        {
                            Label = new DocumentContainer
                            {
                                Value = PlainText.Parse("Quero saber mais")
                            },
                            Value = new DocumentContainer
                            {
                                Value = PlainText.Parse($"SABER_MAIS_{bar.Id}")
                            }
                        },
                        new DocumentSelectOption
                        {
                             Label = new DocumentContainer
                            {
                                Value = PlainText.Parse("Avaliar")
                            },
                            Value = new DocumentContainer
                            {
                                Value = PlainText.Parse($"AVALIAR_{bar.Id}")
                            }
                        }
                    }
                });
            }
            bars.Items = selectBars.ToArray();
            return bars;
        }
    }
}