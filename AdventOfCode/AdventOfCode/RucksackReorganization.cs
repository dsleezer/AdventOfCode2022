using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Rucksack
    {
        public string CompOne { get; set; }
        public string CompTwo { get; set; }
        public string Total { get; set; }

        public Rucksack(string contents)
        {
            CompOne = contents.Substring(0, contents.Length / 2);
            CompTwo = contents.Substring(contents.Length / 2);
            Total = contents;
        }
        

    }
    internal class RucksackReorganization
    {
        
        static void Main(string[] args)
        {
            /*
             *  --- Day 3: Rucksack Reorganization ---

                One Elf has the important job of loading all of the rucksacks with supplies for the jungle journey. 
                Unfortunately, that Elf didn't quite follow the packing instructions, and so a few items now need to 
                be rearranged.

                Each rucksack has two large compartments. All items of a given type are meant to go into exactly one 
                of the two compartments. The Elf that did the packing failed to follow this rule for exactly one 
                item type per rucksack.

                The Elves have made a list of all of the items currently in each rucksack (your puzzle input), but they 
                need your help finding the errors. Every item type is identified by a single lowercase or uppercase 
                letter (that is, a and A refer to different types of items).

                The list of items for each rucksack is given as characters all on a single line. A given rucksack always 
                has the same number of items in each of its two compartments, so the first half of the characters represent 
                items in the first compartment, while the second half of the characters represent items in the second compartment.

                For example, suppose you have the following list of contents from six rucksacks:

                vJrwpWtwJgWrhcsFMMfFFhFp
                jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                PmmdzqPrVvPwwTWBwg
                wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                ttgJtRGJQctTZtZT
                CrZsJsPPZsGzwwsLwLmpwMDw

                The first rucksack contains the items vJrwpWtwJgWrhcsFMMfFFhFp, which means its first compartment contains the items 
                vJrwpWtwJgWr, while the second compartment contains the items hcsFMMfFFhFp. The only item  type that appears in both 
                compartments is lowercase p.
                The second rucksack's compartments contain jqHRNqRjqzjGDLGL and rsFMfFZSrLrFZsSL. The only item type that appears in 
                both compartments is uppercase L.
                The third rucksack's compartments contain PmmdzqPrV and vPwwTWBwg; the only common item type is uppercase P.
                The fourth rucksack's compartments only share item type v.
                The fifth rucksack's compartments only share item type t.
                The sixth rucksack's compartments only share item type s.

                To help prioritize item rearrangement, every item type can be converted to a priority:

                    Lowercase item types a through z have priorities 1 through 26.
                    Uppercase item types A through Z have priorities 27 through 52.

                In the above example, the priority of the item type that appears in both compartments of each rucksack is 16 (p), 38 (L), 
                42 (P), 22 (v), 20 (t), and 19 (s); the sum of these is 157.

                Find the item type that appears in both compartments of each rucksack. What is the sum of the priorities of those item types?
             */

            //Rucksack test = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");

            //Console.WriteLine($"{test.CompOne}\n{test.CompTwo}");

            #region DataEntry
            Rucksack[] bags =
            {
            new Rucksack("DPstqDdrsqdDtqrFDJDDrmtsJHflSJCLgCphgHHgRHJCRRff"),
            new Rucksack("BcBGcQzVBVZcvznTTTvZcGTpCRRRfRCggLflHlhhCZpZCj"),
            new Rucksack("vGQnQvnzTzNTTbVnzGBqMqwqDLdPtMmbwqqLLM"),
            new Rucksack("wLRFRqvFsFRjfrHddbdbjzdH"),
            new Rucksack("lcsnSJPSSVVlGmGrHzbbrGNrdzbz"),
            new Rucksack("mSmlnnPlmJmncVDSlSZSlmLBCvtwBvtLCqqswsDBCTWW"),
            new Rucksack("pfqPrPgmmhvqdlsdWq"),
            new Rucksack("nfjHLJfZcLbVtQWWtndhls"),
            new Rucksack("CzJJFLzRzfDwrmggpC"),
            new Rucksack("CWfllmlCDFlZZqMfmFBWmWLJVRLVwNNtRVGPpwtGpqbJ"),
            new Rucksack("jHndndndcjhscnhHNtRbVtLbGpJbRRcb"),
            new Rucksack("HSrvnQzQSMDlLzBCfg"),
            new Rucksack("BQRVbgQQBJBbBtVBSSSRWMQbdNvvRPjZjCCdPLNZNNsNCCzd"),
            new Rucksack("HwpFpnlGpGZWGvjzPd"),
            new Rucksack("FTDmFrrwDpFMtmQVQQcWgc"),
            new Rucksack("VhbPshVDPDFWhWsgDNMMbVtmBjwBffpwBntnmnqfnswt"),
            new Rucksack("QzzGrTZZdrdlTcCLpRBnmBRRjBCqtptt"),
            new Rucksack("rJdGlmLTJdJrvZDbSbDSWDNbFJgD"),
            new Rucksack("qrcqTBHTcHgwWWdHRjdWBglBbGPpGvvPbszGzsbPpQfPLwPz"),
            new Rucksack("nFVmjhMjFJCSJsQQPQLbLpzCPQ"),
            new Rucksack("SnMSVVZSJMNMZNDVFtJtNRBdqBrWrRHWZTllrrjgHq"),
            new Rucksack("ZqdqcrPqqrwnQqnrZqjVcqrQwwmNbzNzwbNLzvFbHLbNmBLF"),
            new Rucksack("LCDsCsRTfLTDszzNbsbNNHbs"),
            new Rucksack("gLfCgShfCgMPlPrVcqrQgn"),
            new Rucksack("QSNSLDQDLfqqPwwBNLqgqJMMmmRRCTzHnCHhRzHmfCmh"),
            new Rucksack("lGvdbdWdVvsVszpDhHmmlnMpTC"),
            new Rucksack("ctbdtVsbbvvsbWZFdVQJqPtgLQBDBwBQPJwJ"),
            new Rucksack("dggSSDCPddRWPnSSPWRDgdSrTDsDQDTzQGGTMbsMMVsQfTfV"),
            new Rucksack("jmBvtFpBcBhhjljZHphztMsCbsTTCbzsqGqsfz"),
            new Rucksack("hccpLmhFlcwCrPLrCPnL"),
            new Rucksack("MMHZnGrCfJnfCPggSSGGSSSgLW"),
            new Rucksack("qhFhRlDFDlqFsgdvJdWdDdcSvp"),
            new Rucksack("wVlhqTbbRNFqswlVVRNbZfHCrntMBrTTZnJMCfnn"),
            new Rucksack("sHGZscVGHJMtmRrqzRqqqTqt"),
            new Rucksack("SjvvNgjLShWWhhSQNWqmrBzlRllTTgBqnRmq"),
            new Rucksack("LNQWLfWhSQvLdCddWWPHMcbHHrJcDGFZCJssFM"),
            new Rucksack("mSDjSVQbVGbmqDVbHmqqJTZzPHTHhhRJhwsRPcRJ"),
            new Rucksack("tFfFFttFdsNntfpMMppJWwZTzJczJcZPzwWcdJ"),
            new Rucksack("vNtgCrpgNptptgCCbbmjbSbvsVjSsjGG"),
            new Rucksack("VCQlZJCTPRWsBsjTTT"),
            new Rucksack("wvNrnbbvnhdNhLMfGsrGpRFpGpjp"),
            new Rucksack("dwndHbHbbLqwwhNcLsqSHSCHJClQtJSttQDPSJ"),
            new Rucksack("ZlrvrdvpGBBhlDrshdqJHRPHqPTJzRPPqw"),
            new Rucksack("tcftfSgFFgcgLPmPmpnqFwJRHP"),
            new Rucksack("pWLCcWNNNNttMNgZvlsvrBrsrjWDjB"),
            new Rucksack("wgdCJgDMDwMCwDMCMJsJJfpffVpVfbfrrrrgjgllZp"),
            new Rucksack("QFRhvttRthtQzzmpBWbWzWZSVpbSpl"),
            new Rucksack("btRttRLttGNqvbFHLwCdDcMwnPPJDnDD"),
            new Rucksack("VhmMNllLqGLJQNhRfZHgSPfgSPTqZj"),
            new Rucksack("sBwDcwBtsdzvvHZRlPRjDZTgPZ"),
            new Rucksack("pWvvBBcBCdzNLVQVWQlNlW"),
            new Rucksack("NsSppvSjSPNBNLJJLh"),
            new Rucksack("fCGtqQbZZGZQZTbtzbqbCZThddcMBddlJGhdlBMcddgLlJ"),
            new Rucksack("zZFTqwLtTRFqTQwvmprnRVSsDrnvVR"),
            new Rucksack("FttFTzzvlVHFzTjpbvzbFSDDdVGhdqLGWGJdVDDfsLqG"),
            new Rucksack("cmBNCRnwsCcBPMfLLfJGcWhWqfdh"),
            new Rucksack("BwPmZZMmZMCsnrwMrmbHHbjbSvSbjvrlHpzj"),
            new Rucksack("sZQHCBFHQQQPGQCCHCHwsHFshhtSnnqjbRSSPngnhbRjqVPn"),
            new Rucksack("mzLvmDvNNWvNvrzzrMTzJNjqndqbnSnnRgTdtjdbjhTt"),
            new Rucksack("WzzWDlJLzLDvMWJJlMzmLJWcpHFQBpBgBHGQGBHfwwBfQQlG"),
            new Rucksack("gdpFrdrmrDsqqswdtccgWWCMlChSbhqSlCzBlSqh"),
            new Rucksack("TTvjrfjNJPnRQNTQjvNnCSWBVBVbClPSVSbSVhSh"),
            new Rucksack("HRvnfTfvjjHZTDsmcHDsrDsdmp"),
            new Rucksack("bFChjhbpbjqsntjtns"),
            new Rucksack("vdWcfMHfddvrlNMNdWWTNgBqDngBBZBBQZshgSfgnD"),
            new Rucksack("JlwrlrlhlcJWcWMwhWNVFpLzwPbbLRFPppVLzm"),
            new Rucksack("DtBtgLvgcHzllsTwzSTg"),
            new Rucksack("vhhjZrCrZdVdZVSwPMwwTTMGwT"),
            new Rucksack("nmpfqrnZJbqBBvRc"),
            new Rucksack("nMvSLvWSWPVPvWnSLShFLBjVbpNVGGbVQbbNcBcBBc"),
            new Rucksack("sTzJsJszbbQbdQJb"),
            new Rucksack("DsDrwTtsCTFhLQSShRwh"),
            new Rucksack("RNFQhTQqHNNGRsNqQFNsHhFCwwPLwPqwzfPrrPBwpJSJJw"),
            new Rucksack("vMMMblZjddlvWbjbBBfbwCrPPLJppwCL"),
            new Rucksack("jDmvcDBlBdjVglgddmvDQRNFtFRGtQhstHNsGFHV"),
            new Rucksack("rhLHmZnMrRsZSstZLLtZnhSCNbbmPJVcblTNNTlccpNTjJTj"),
            new Rucksack("WFgGddGFFgFDddMblpJjlTJTPc"),
            new Rucksack("QGWqBBfWgBqWwFwzMGvzDqSSrHnCHsrssCRZrfRhHLfH"),
            new Rucksack("HHzcWqNPmZcqFHPZGBdMRBMDlllWpRDJMl"),
            new Rucksack("tTgSvPhbMDJlbJQb"),
            new Rucksack("SCTtvtSPftswjvPhTgffVqmGZLmqmCCcqZzZHFNznF"),
            new Rucksack("QNpppRrdZvdgzpQZNpgRRgbSwmDDvFGGqwJSsvSGSqGG"),
            new Rucksack("HchWBMcBVnnWcHPjHhWcjHTqJFDGMSSqDMwJJbGwSsGGSb"),
            new Rucksack("tcCVcBjPjhnWlFrCFNZflQNr"),
            new Rucksack("HsVMrqrPqvvgprSrLG"),
            new Rucksack("THJWBJDwRFvBgGSzgF"),
            new Rucksack("DmhfHnmQncMNVMqPqbcd"),
            new Rucksack("SqZmMJqvHJBhHJLp"),
            new Rucksack("wsgTVTSsPssjjFVrTrFlhLhCFlBBnHplHLLHfF"),
            new Rucksack("zgggdwPrRrsrjjgRwVwdwdQTmvMvZqDZbWqqMSNWNbGQbGZN"),
            new Rucksack("fBDBfLZnTLZVVmmDcQMDDV"),
            new Rucksack("jPFtJFpHpJqfJFrptwrJdRWRWNpQVmQRMWNVVVNVvQ"),
            new Rucksack("zHwJgtFrTlslfghf"),
            new Rucksack("wMwTttCCTTSTfBmPzPVZnPZLVVtbnN"),
            new Rucksack("ldRRRlRHggGcvcRbZsNzvBVWnnPBWv"),
            new Rucksack("hdlJHgpcJccJhQdJrcrhwFMpDqCwCMBqjSqjqpTC"),
            new Rucksack("fJfnwJJnnHJgJHTgjsjDccNjcbgNjm"),
            new Rucksack("VdLqRRqGVqpRrPpppMBjDNmDctdsBlNjmZdZ"),
            new Rucksack("PDQvPQSvpGDrTwfJzzfFnTnS"),
            new Rucksack("MnHvnHHMRMzPTlDLPPRGcl"),
            new Rucksack("dFnfhFVwhdBPBfGWlPcP"),
            new Rucksack("JNrQFsnVtwsgvNzvmMjpzS"),
            new Rucksack("BZVPFpNpcNZpmRRPpzcVNhLLnssDjjDGnqjjLDFDjq"),
            new Rucksack("mMJbJvtJQQHlJDGCDnjvChDSsv"),
            new Rucksack("MQwWJHdQwWrJltQrgfNPmfBcBrpBpZ"),
            new Rucksack("ZWZqDsZZqWsWvWLPwPbpHjdtSbSjSCSPPSCp"),
            new Rucksack("MFVNMLmFmNzcTTrFrLbjdjbpCdCSbTCShRSd"),
            new Rucksack("czNzLrznlGNNrMzMwDlJwJWDwJwqJDvW"),
            new Rucksack("GlgchGGVShlQcQfDhzZrNFnFNFNjFzNFcn"),
            new Rucksack("dwCtpwHTtPTWpdFNfJJzRzvJNR"),
            new Rucksack("tLBBmWHftBttPbLwCHWTsSSQVglqgMsMBDSMGlQS"),
            new Rucksack("RDDDGhGfvPPTTPTThn"),
            new Rucksack("ZFLMmjpCpfMZzFqmqsCmPjdVBlVBVnWBPNTVbnTV"),
            new Rucksack("zHqJMCzLvftRQQHG"),
            new Rucksack("nTcbnvPsvdvFzpczVZmMGg"),
            new Rucksack("BCCJwSDqhQLJmMMpzGZVFVFB"),
            new Rucksack("qhrwJwrJrrzJNqwWLsTTnlTlbnsvbstWsW"),
            new Rucksack("vHRbqPJZvRPZhShJvTZllZtgzwlfBGBlsm"),
            new Rucksack("VdQjVVCssQVrWrQmTBgBzglmgCBGml"),
            new Rucksack("NnpQNpcFpNWshPRLsbSFsH"),
            new Rucksack("cVGmVZVwVVMLdvcRttTdbB"),
            new Rucksack("ppCQrwzHBtLrttLb"),
            new Rucksack("hsFJQzFWCpCqjZGVwlhlPP"),
            new Rucksack("HDGRzgWhgfzVWfRpspwRwbwStSwt"),
            new Rucksack("ZBPPPmmmTMQMPcZrBmSptSbbQCwtlsNqCwjC"),
            new Rucksack("TTLMMmZvPTrMZvFMmcmvrTccDDnfGHJgJhHhnhnLfVhSWDJz"),
            new Rucksack("pNrpjzthZPnGrzzWbJLLLbbJZwgSvZCV"),
            new Rucksack("MQsFFFDTfMNfRFfBFMdBdwLSvgbSTVCqTgVbbTLvwV"),
            new Rucksack("BQlQDMFccQsNmWpPGhpcjr"),
            new Rucksack("CTgGRCRglLlLTllL"),
            new Rucksack("vMJmhPJcmPBMvhqPDnNNqlWnwDWqsRQs"),
            new Rucksack("hcBfcJRPFfvvRvJZBrfMPZdpbSSGtSdtdgtzzSZzbV"),
            new Rucksack("NQLzNzzJcrLrSgZSSGgZrR"),
            new Rucksack("bTsjqHvcmTHvjgZGDvDpGZRfpg"),
            new Rucksack("WqTVPbdnMlLJncQC"),
            new Rucksack("hZLBrqLGLMbzLLBhfMMrnnNJlnNnlnJJNNdCJdzN"),
            new Rucksack("TWTsWqvtvpTSgRHpVFdjgjCPdgJlCFCFnF"),
            new Rucksack("swSTsTwpTVRmVRRRqMDMfqfDwLfbrhLr"),
            new Rucksack("NTQHWNQWrQwSTDWlcPPBHZBZbPgZJZ"),
            new Rucksack("nmfjCRCfRhndJcjBbcbcbg"),
            new Rucksack("nsppRfssfzCnqgzTzrwTwQVTWM"),
            new Rucksack("mFjQmDGmbbGjmChrCwdQBHCHWh"),
            new Rucksack("qvZZnPvvnngMpnlqpMZnpsTgWHTRCWrVdVDBWRhHBrhHDHhd"),
            new Rucksack("vqZgnnqgLvqlPllpnjGDjmNjNLfftftLFD"),
            new Rucksack("rfGsjsMNnFMMFddMsttDMgLHGlmJLCPPmHHGmHPlmm"),
            new Rucksack("vZcbhQbrRbVZPJLwPTgCLlgb"),
            new Rucksack("hchzSBqzQvphnWnrjFdWMqff"),
            new Rucksack("WmfPWfVsfqszRDqPqgpvHhvdwddGMmGghM"),
            new Rucksack("QtTrtTcSBjtQCctStrTrzhpwjGvGHhngwMHGHvMv"),
            new Rucksack("TtTQlQFcSSJlcccBbltQQTTRsPZDsWzRFzWFzPNfsssLPs"),
            new Rucksack("QpNNMrjcNMccGNdvLBBlBsBjnsnF"),
            new Rucksack("tTSqbbbqCtWWCTWSVTmmCJPwVwnwvFPnsPVnnPfddlvf"),
            new Rucksack("HmhJTZWqHqCJJJltqpNGRgzZDcQNrgzDGM"),
            new Rucksack("HcLVRhhTRsLRRVjslTscqNQmVNQQgQttqNwNZtmw"),
            new Rucksack("nJdBJJhfFPSCbJBJBMbzFbFgmNmtgmvgNgnntNwZQQNNmw"),
            new Rucksack("bMbPzJbzCBPrJfdfbBbdCrGHlLTTpWjsGhGTTRTRlc"),
            new Rucksack("sJCCpQJQCrfCfnSCrT"),
            new Rucksack("vmqgNggzgmZqmPShqBhThfhDhjDhhB"),
            new Rucksack("RZNzHRzZSQwHwHVVWc"),
            new Rucksack("jtVtvVHgvjJbHjjQPMZdCcwlMdNbdFlNlc"),
            new Rucksack("WppSBDzGfBzTBqQWwCFMlwZMwMcZ"),
            new Rucksack("zBfnqpRGnSSqTfqpTpSnnHQsjJgQvPJshHtHVh"),
            new Rucksack("qJMRMcPPVzVhmsDWfhWT"),
            new Rucksack("BglQBNlgZtQBHLHHBnTjWSWmFmwDmWjSsnmF"),
            new Rucksack("BdHvgHBvBtZbTpJRPCdcdpGrGJ"),
            new Rucksack("pcGcWGWlvQZpzmDbgFmz"),
            new Rucksack("HqqnddDdddjzTTggjZgFtT"),
            new Rucksack("sHqRwrRsJswLHrMLLRJdqNVVrGffPGWcvSSWlDfGfc"),
            new Rucksack("lttTbgRvqvtQRhjLzGjLVh"),
            new Rucksack("JJfrHfrdffZJQmZhLLZVVwFj"),
            new Rucksack("sBjCfSNNTTqnCnqD"),
            new Rucksack("qMtWjSrHftGfjqrJGMqzVzFmBBrzQQwzgBVQVQ"),
            new Rucksack("LDChPbThbTcTpCTcnPPQPQzVPvvzQBBWgVBQ"),
            new Rucksack("ZLspppLpdZZttdHttqdWMf"),
            new Rucksack("htJcJhpMQQWjhNWdJQSCFCTvFBPCTDlMmDCFlM"),
            new Rucksack("jjbbsfjwZbLGVVqHCFPvmvDmClTfmP"),
            new Rucksack("zjVVRwZwnRJtnNQt"),
            new Rucksack("PCPVSzLMMRqGwgMmHmQmDQ"),
            new Rucksack("slrrbZZgsfcdsgdhrHFGQHQFwvfwFwDGTv"),
            new Rucksack("NclhgpctrrNjllcZdcrpZnPPqzLLSSLqJLtJWCWzCn"),
            new Rucksack("PBLSBPVBwpTVppfT"),
            new Rucksack("lZCqQQtCQGPJJPtPHHwTwZTTZpwHsfRH"),
            new Rucksack("mCtGFDqFGDGQjPGqjJMMlqPgdWgSSgBWWcWzLdgvMzgBMg"),
            new Rucksack("cLBrfchhFBcnrgvqvPGvvwSS"),
            new Rucksack("QpzpstDDZMwDZqwh"),
            new Rucksack("WzpbWTjsbhpQtjThsjJFRNLnfLbfRLRBLlFB"),
            new Rucksack("ngnWWqnfgqtfsrWftqsrFWPSdSSdRCTHRSwpRGTfGmSG"),
            new Rucksack("VhJhVczJQcvbvvlhBpvlPdmlwHRTGHSRPTSCRGTd"),
            new Rucksack("zVcBcMhzcVcvMJJJDpWrsqrtrWLWsgZZFtFD"),
            new Rucksack("fbccrJlrffTwJDJTtBtB"),
            new Rucksack("hRNNFddsgsFPLLRVVwthMCQTtBwrtT"),
            new Rucksack("jrsPGLNjsqPlvGbZbcvScz"),
            new Rucksack("HFPmmgQrQzFgrLVPPrLFPNDJNJzzcGbJTbsSzbGGNc"),
            new Rucksack("MtvCMhJBdnMhwfhlwnfBfMDCDSjGbqDNGNGqGjDDjsDC"),
            new Rucksack("wwnhhdtBBptwdlhlRntRldJFVWRFPmWZFmHRZZmFQPRWmm"),
            new Rucksack("WrHNNTBNTTTBwHHcSTrBnSzJPFnpJfpLVfpDVdJLFJLFdD"),
            new Rucksack("hRthQvhRQlQmDpfVJFdLlLLj"),
            new Rucksack("hMZZbCMvgQgBTBGNGDcWbr"),
            new Rucksack("HvQjMRMTzjsCQzHTCFfVVZLPVvfLfPVpZg"),
            new Rucksack("GtlbBtSGlSbDdStrhSFCPVDgZgLLgPpPJWPF"),
            new Rucksack("rmwSbcbcdbrbGljQjCzCCwnHRqQT"),
            new Rucksack("bbgNSHPPgnmMMZtNcMpp"),
            new Rucksack("VFzFDFVtCBFDCVFdMlhZMhdhmhmplwZL"),
            new Rucksack("JVtBjGRFRttFCGDFGJJDQQgSgTWPPfSSfWbQnHvPWW"),
            new Rucksack("NvdBpwNvGNFvpBGGBmLFblrtVTwDttlhtlblfQbQ"),
            new Rucksack("SCMMsWCMSRZCqsmWcRWgRRsVtlrtrQbtQftThrQTQtqrtQ"),
            new Rucksack("WRscMgZJJCJWzZgSWNLFdBNHGzpFGmBFFG"),
            new Rucksack("qghqRVzhLNRLqzLhVztgQdLFdrccCnSpcZdSZcTS"),
            new Rucksack("DwvmHDJDsmvDGmHbQBlslMDDCrTCnppTndrdBrFnFTSdCCnZ"),
            new Rucksack("GGwJHlGwwvMHJljwwDMVtfhtWWhzqVPPjfQRqz"),
            new Rucksack("BsDMPrqPzsDwwCLGmqjpjm"),
            new Rucksack("VfFJQlVQcvfwJLJCJppLNp"),
            new Rucksack("vfcSHCglCgbgbbbFvSlvQfPsrsZrPzZzDWWStPhtZPDP"),
            new Rucksack("gjMsnFgbnllbjMfSZBHHtpHvvvFwhv"),
            new Rucksack("DDRZDLdVCLNLJwBCShQHHwwBzv"),
            new Rucksack("DNJNTLJRTqWmjWZnjrlmjW"),
            new Rucksack("ZTSVSFZCLTnvzfzqvnNL"),
            new Rucksack("PfPcJljfMpvtlnztvQtw"),
            new Rucksack("PsJMMMWpGcgMHMfjRBThrgrTbBSBFdVSTF"),
            new Rucksack("GccBRWjgtQqsTcVQcw"),
            new Rucksack("JhJCMJHPLffMChlfLCLHMMrDQsQqDVQsqTDbVvGqDhhzqD"),
            new Rucksack("dHGlfnCHlJrNmtdptggpmW"),
            new Rucksack("wnDDSBCSBSDLzLLmHLrlwlmpTTqzGJJfpjfjNpfqbpbdpG"),
            new Rucksack("MMRhFWWRvZPZRZQhFZMVhVSNqjqpNQffJjbjfbjdTJbp"),
            new Rucksack("VMMsWcZRWgMPvRSrSHmsrrtwSHnr"),
            new Rucksack("TQchPTgjBcNgPHhhThtNzQdzdsCmRDJnzCCmCdCm"),
            new Rucksack("vllVwrfvbSBVFSbVGwlrFGlqRCDzRJCJdzvJRzsdLDDLsdCm"),
            new Rucksack("VrMrqSWbfqWbBhhpWjNTttpjjP"),
            new Rucksack("rsfvSHHcvwrMPtcQZgnDhGdvJzngLzzJLJ"),
            new Rucksack("lWmVlfbCCNFCpBCmTpFFJgzhDLGhmRGhLhmGdgGR"),
            new Rucksack("pNBfflVTNpfWTWbWWbjNVqBsscqsqrZSwMwZrMPZSZrZrs"),
            new Rucksack("PJPHPJmhhHhlHPQgCndngTbWnqCWDGTD"),
            new Rucksack("tSwccFpFqwMcFbGFWvnnWvCW"),
            new Rucksack("MwLwLMSwpNBBtctSctfhZHJQhhqmlRlZRNPH"),
            new Rucksack("GNzdZhVGvtGZVVgGgtfHHWhpLPPpLWpWWnHf"),
            new Rucksack("RjwqRcDTvCrWJWWnlLnnqn"),
            new Rucksack("DbrDDwwBwjjsrbDTRTBmwgZmgGgmdttvQvQFSQGFtg"),
            new Rucksack("jRgcZRfhmHfZjPZRgHffLFTzzddBTBBFzLDZzBTF"),
            new Rucksack("VtsJwSbcStlwMqbtwbvWBWddGGdrFDDWJWrzTT"),
            new Rucksack("VwsQQvlbVbVlbNllVwbMmmpnjpfChfQpnhfcCCnH"),
            new Rucksack("dFnFjWjTQTFzFWPWPgqhRQRqgVhRqfRqQJ"),
            new Rucksack("bStrbpmNGHSrBDmrNBtHBhMVLLqLqVVglrllPVLgPg"),
            new Rucksack("tSsbBDmBbbGmmSHDbtmHbtNCjnzscZccjnPcTcdzWcvjswFz"),
            new Rucksack("lFCjDhqggMlDvMhFDgqFFzHHwHwwwTpLBwmwqmmpBpwT"),
            new Rucksack("GPdPnStGncQGNStZPpBmVZmRmfzTRmVVfL"),
            new Rucksack("tWtNdPWzsbtMDCbrCbrjrv"),
            new Rucksack("BJHMgLlcMTBLCtbqmMDGppmmMM"),
            new Rucksack("ZFPsrrdvwrNvrdNZsvhrrzzRSmJRbJSmbztsmpRSSm"),
            new Rucksack("NwhfPZFNdFQPVQdvZFNgjglJLTCQngQWllBcTT"),
            new Rucksack("jGlQQvQvpRQRGfnPLfcfGTnP"),
            new Rucksack("BMqmdBVBwmFdVMFZdcTPqgLnnggTTLSzPS"),
            new Rucksack("FVtMMVcbZVrcZMQCHjHWJJCJDvrW"),
            new Rucksack("rPPwVwbpRbbVlllTLCTRqTLL"),
            new Rucksack("dNdZssBBCBszHsjhDTQgqLDvlTgDZgll"),
            new Rucksack("dSsCNNHMdsdWWWmpGfmPFS"),
            new Rucksack("rzCLrsjgZjwcwSZc"),
            new Rucksack("wNBNRJpRltHNWWRHBlGlJtRcTZSVBmZDVqZTfBVVTDTVTD"),
            new Rucksack("NWPtGJPNGWHvpvtwvWgzQvdvQQzhnsnCvCLM"),
            new Rucksack("HHbJhzddMPbPgnDWbZ"),
            new Rucksack("BLnjLNvBrrcvvvwnwLrnqrgpPRgRNCWgZDPPpDgRpRWp"),
            new Rucksack("jtsBqScStfJQnnVF"),
            new Rucksack("QVFSVgQFZZQlQqQSlgQpRppSbRTSTppJJbRpLb"),
            new Rucksack("cGwCDwjrnrGvzBzGnwwvDBjnpLbsLTTqRPbsJPMJMWpPns"),
            new Rucksack("tcGzrCdtGdQmVZqVNQ"),
            new Rucksack("RtTRhncVMTVccShRTctLdfPdJpLPqJhZphHpJs"),
            new Rucksack("BzssCmFNWWqWwqwPLH"),
            new Rucksack("svzvvsmmFBmsggrGlGMVSMtMRRncSQScRRRl"),
            new Rucksack("rmmqrQQwLbbGrrGr"),
            new Rucksack("cNJzzzWtWmLCGGbLWWbv"),
            new Rucksack("cVtMppchzMBVMcNJcMsRwqZFMlgmggmRgg"),
            new Rucksack("mQsQBHFMrbddbRqH"),
            new Rucksack("NzhcQNfNNtzvWwZdSrgbrprPrwLbgb"),
            new Rucksack("zcJVhTtNNcvcfVZmBmQMGMMljTCmlB"),
            new Rucksack("FlldqjSlCgfvPFfvFF"),
            new Rucksack("rbnDtVBMbprTsbVVcTDTrpMcmNwgHPgghTmNfLwvfPNLwhdT"),
            new Rucksack("drMppdnbbtQDBtbnsBbcrrtbSqSSRCjlQZWllllSRlWRGCCC"),
            new Rucksack("nqdCsqbbwdsrHFVJHcwFTc"),
            new Rucksack("jPPjtWjPWgRltRLsBRrNpHFDHVFWVVJNNHrD"),
            new Rucksack("fgllPGQjBffLjtzSsqvbSSzGvnhS"),
            new Rucksack("zsVBzMfHHnzlwwVlqcJJFT"),
            new Rucksack("ZzRLvLDzQzTmlWlqWRWF"),
            new Rucksack("GbQQvpGvSSpjdQjSQZpQZGLfrgBCsHzrdtCsnfCBHsBgdH"),
            new Rucksack("zBLbLWzqqwLMnMZTnHlnsHTvFlFHNT"),
            new Rucksack("fjhdcrjjdVdrGSmmdfccGclPvlvPTlGHTFgNvNgqFFvg"),
            new Rucksack("pmmcrcRrjSVJchqVccjpRwZMDwCJQBbLDCCbwBWLzL"),
            new Rucksack("TDMBgBgLlcjBfMfcVJVmGnnJjvPVCPVv"),
            new Rucksack("zzptqHstJqFzzdJJZNvNpvNpnNvGnNZm"),
            new Rucksack("dHszrWQhdzHQqdztwQBLSfglfDbfJlJTLg"),
            new Rucksack("VTmvrldtGGwmlvmGDHlLnFDCCplFQHLH"),
            new Rucksack("ssgjzSzzJCQSSFVVQF"),
            new Rucksack("WsRWhgVqRtfvwcddhc"),
            new Rucksack("bdlDwznhnNlffMcPTPfzzQ"),
            new Rucksack("srCRGRrZCmVTBfBBfTQcZb"),
            new Rucksack("brSrrGvRVvWmRsrHrWSbjNJwdDFhnNlwtlnSdnhN"),
            new Rucksack("QQqqRfdQQSdjgPmZfBmmPgRhphphJtLmJhTJJhVbTtLhTb"),
            new Rucksack("vvlNGzDDDcslcsGDlWHtCFVpcCbThFTtbJFtCh"),
            new Rucksack("DrMGlzMVwNGWsWMHDMvlzlMfZdQdQPZfSZRfdrPBfqRZgj"),
            new Rucksack("qVHfHNJCHVvvFFbfFlHHnCQQDhLnhhhPZrZnPZPn"),
            new Rucksack("mSMszWRMQmhqrnZL"),
            new Rucksack("GjtzjSSdRGSjsRtdRMttgGgsqqFNfFcGVvVVvlbHFFGFVFwb"),
            };
            #endregion

            string incItems = "";
                        
            foreach (var bag in bags)
            {
                incItems += string.Concat(bag.CompOne.Where(b => bag.CompTwo.Contains(b)).First());
            }
            Console.WriteLine(incItems);

            string priority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int value = 0;
                        
            foreach (char c in incItems)
            {
                value += priority.IndexOf(c) + 1;
            }

            Console.WriteLine(value);

            /*
             *  --- Part Two ---

                As you finish identifying the misplaced items, the Elves come to you with another issue.

                For safety, the Elves are divided into groups of three. Every Elf carries a badge that 
                identifies their group. For efficiency, within each group of three Elves, the badge is the 
                only item type carried by all three Elves. That is, if a group's badge is item type B, then 
                all three Elves will have item type B somewhere in their rucksack, and at most two of the 
                Elves will be carrying any other item type.

                The problem is that someone forgot to put this year's updated authenticity sticker on the 
                badges. All of the badges need to be pulled out of the rucksacks so the new authenticity 
                stickers can be attached.

                Additionally, nobody wrote down which item type corresponds to each group's badges. The only 
                way to tell which item type is the right one is by finding the one item type that is common 
                between all three Elves in each group.

                Every set of three lines in your list corresponds to a single group, but each group can have a 
                different badge item type. So, in the above example, the first group's rucksacks are the first 
                three lines:

                vJrwpWtwJgWrhcsFMMfFFhFp
                jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
                PmmdzqPrVvPwwTWBwg

                And the second group's rucksacks are the next three lines:

                wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
                ttgJtRGJQctTZtZT
                CrZsJsPPZsGzwwsLwLmpwMDw

                In the first group, the only item type that appears in all three rucksacks is lowercase r; this 
                must be their badges. In the second group, their badge item type must be Z.

                Priorities for these items must still be found to organize the sticker attachment efforts: here, 
                they are 18 (r) for the first group and 52 (Z) for the second group. The sum of these is 70.

                Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?
             */

            string badgeLetters = "";

            for (int i = 0; i < bags.Length; i += 3)
            {
                badgeLetters += string.Concat(bags[i].Total.Where(t => bags[i + 1].Total.Contains(t) && bags[i + 2].Total.Contains(t)).First());
            }

            Console.WriteLine(badgeLetters);
            int badgeValue = 0;

            foreach (char c in badgeLetters)
            {
                badgeValue += priority.IndexOf(c) + 1;
            }
            Console.WriteLine(badgeValue);

        }
    }
}
