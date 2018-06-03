/**
 * Copyright (C) 2017 Kamarudin (http://coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/rudi-krsoftware/open-retail
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace OpenRetail.WebAPI.Models.DTO
{        
    public class KasbonDTO
    {
		[Display(Name = "kasbon_id")]		
		public string kasbon_id { get; set; }
		
		[Display(Name = "karyawan_id")]
		public string karyawan_id { get; set; }

		[JsonIgnore]
        public KaryawanDTO Karyawan { get; set; }

		[Display(Name = "pengguna_id")]
		public string pengguna_id { get; set; }

		[JsonIgnore]
        public PenggunaDTO Pengguna { get; set; }

		[Display(Name = "nota")]
		public string nota { get; set; }
		
		[Display(Name = "tanggal")]
		public Nullable<DateTime> tanggal { get; set; }
		
		[Display(Name = "nominal")]
		public double nominal { get; set; }
		
		[Display(Name = "keterangan")]
		public string keterangan { get; set; }
		
		[Display(Name = "tanggal_sistem")]
		public Nullable<DateTime> tanggal_sistem { get; set; }
		
		[Display(Name = "total_pelunasan")]
		public double total_pelunasan { get; set; }
		
	}

    public class KasbonDTOValidator : AbstractValidator<KasbonDTO>
    {
        public KasbonDTOValidator()
        {
            CascadeMode = FluentValidation.CascadeMode.StopOnFirstFailure;

			var msgError1 = "'{PropertyName}' tidak boleh kosong !";
            var msgError2 = "'{PropertyName}' maksimal {MaxLength} karakter !";					

			RuleSet("save", () =>
            {
                DefaultRule(msgError1, msgError2);
            });

            RuleSet("update", () =>
            {
                RuleFor(c => c.kasbon_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
                DefaultRule(msgError1, msgError2);
            });

            RuleSet("delete", () =>
            {
                RuleFor(c => c.kasbon_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
            });
		}

        private void DefaultRule(string msgError1, string msgError2)
        {            
            RuleFor(c => c.karyawan_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
            RuleFor(c => c.pengguna_id).NotEmpty().WithMessage(msgError1).Length(1, 36).WithMessage(msgError2);
            RuleFor(c => c.nota).NotEmpty().WithMessage(msgError1).Length(1, 20).WithMessage(msgError2);
            RuleFor(c => c.nominal).GreaterThan(0).WithMessage(msgError1);
            RuleFor(c => c.keterangan).Length(0, 100).WithMessage(msgError2);
        }
	}
}