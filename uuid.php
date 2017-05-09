<?php
function uuid($v,$d,$s=''){
  $u=hash($v^3?sha1:md5,$v^4?$d.$s:gmp_strval(gmp_random(4)));
  $u[12]=$v;$u[16]=dechex(+"0x$u[16]"&3|8);
  return substr(preg_replace('/^.{8}|.{4}/','\0-',$u,4),0,36);
}
?>