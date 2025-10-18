﻿using System;
using System.Collections.Generic;

namespace SuporteTI.Data.Models;

public partial class Anexo
{
    public int IdAnexo { get; set; }

    public int IdChamado { get; set; }

    public string NomeArquivo { get; set; } = null!;

    public string CaminhoArquivo { get; set; } = null!;

    public DateTime? DataEnvio { get; set; }

    public virtual Chamado IdChamadoNavigation { get; set; } = null!;

    public byte[]? Conteudo { get; set; }

}
